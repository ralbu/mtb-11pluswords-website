// #r "nuget: HtmlAgilityPack"

open System
open System.IO
open System.Net
open System.Net.Http
open System.Threading.Tasks
open HtmlAgilityPack

// "d:\Projects\mtb\mtb-11pluswords-website\src" guides.html
// let root = Path.GetFullPath fsi.CommandLineArgs.[1]   // site folder
// let page = fsi.CommandLineArgs.[2]                    // page, e.g. guides.html
let root = @"d:\Projects\mtb\mtb-11pluswords-website\src"
let page = "guides.html"
let baseUrl = "http://localhost:8080/"

// 1. tiny server, runs in the background
let listener = new HttpListener()
listener.Prefixes.Add baseUrl
listener.Start()
Task.Run(Action(fun () ->
    while true do
        let c = listener.GetContext()
        let f = Path.Combine(root, Uri.UnescapeDataString(c.Request.Url.AbsolutePath).TrimStart '/')
        if File.Exists f then c.Response.OutputStream.Write(File.ReadAllBytes f)
        else c.Response.StatusCode <- 404
        c.Response.Close())) |> ignore

// 2. load the page from the server
let client = new HttpClient()
// let pageUri = Uri(Uri baseUrl, page)
// let doc = HtmlDocument()
// doc.LoadHtml(client.GetStringAsync(pageUri).Result)

// 3. collect and test the links
// let links2 =
//     match doc.DocumentNode.SelectNodes "//a[@href]" with
//     | null -> []
//     | nodes ->
//         nodes
//         |> Seq.map (fun n -> n.GetAttributeValue("href", "").Trim())
//         |> Seq.filter (fun l -> l <> "" && not (l.StartsWith "#" || l.StartsWith "mailto:" || l.StartsWith "tel:" || l.StartsWith "javascript:"))
//         |> Seq.map (fun l -> Uri(pageUri, l))
//         |> Seq.distinct
//         |> Seq.toList

let getPageLinks(page:string) =
    let pageUri = Uri(Uri baseUrl, page)
    let doc = HtmlDocument()
    doc.LoadHtml(client.GetStringAsync(pageUri).Result)

    match doc.DocumentNode.SelectNodes "//a[@href]" with
    | null -> []
    | nodes ->
        nodes
        |> Seq.map (fun n -> n.GetAttributeValue("href", "").Trim())
        |> Seq.filter (fun l -> l <> "" && not (l.StartsWith "#" || l.StartsWith "mailto:" || l.StartsWith "tel:" || l.StartsWith "javascript:"))
        |> Seq.map (fun l -> Uri(pageUri, l))
        |> Seq.distinct
        |> Seq.toList


let links = getPageLinks "guides.html"

for url in links do
    let status = try int (client.GetAsync(url).Result.StatusCode) with _ -> 0
    printfn $"{status} {url}"
    let shouldOpenThePage = status = 200 && url.Host = "localhost"
    printfn $"should open {shouldOpenThePage}"
    if shouldOpenThePage then
        let innerLink = getPageLinks url.AbsolutePath
        printfn $"innerLinks: {innerLink}"
       // need to add the list of links into a collection then check if it exists when calling so not calling the same link multiple times