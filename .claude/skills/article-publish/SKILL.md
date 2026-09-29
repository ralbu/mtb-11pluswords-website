---
name: article-publish
description: Use when implementing a new article for elevenplusworks.co.uk from a GitHub issue. Covers title tag and meta description, OG tags, canonical URL, correct folder placement, cross-linking, the guides.html section, the app mention, and editorial conventions. Always consult this skill before creating or editing a file under /articles/.
---

# Article Publish

Implements an article from an approved GitHub issue into the site, following the checklist below and the editorial conventions in `CLAUDE.md`.

## Publishing checklist

- [ ] Title tag + meta description written
- [ ] OG tags added (title, description, url)
- [ ] Google Analytics tag present in `<head>` (via shared template, not pasted manually)
- [ ] Canonical URL set
- [ ] Placed in correct folder (`/articles/`)
- [ ] Cross-links added to/from related articles
- [ ] Homepage "Guides" (`guides.html`) section updated
- [ ] App mention/link included naturally

## Definitions

**Title tag + meta description**
Write a unique `<title>` and `<meta name="description">` per article, matching parent search intent (not generic site branding repeated on every page). Keep both within normal SEO length limits.

**OG tags**
Add `og:title`, `og:description`, and `og:url` in the `<head>`. `og:title`/`og:description` can mirror the title tag and meta description unless a shorter or more shareable phrasing is clearly better for social previews. `og:url` is the canonical URL for the article (see below).

**Google Analytics tag**
Never paste the GA script inline in a new article page. Pull it from the shared template/include used site-wide (tag `G-2P05H77QFG`) so all pages stay on one source of truth.

**Canonical URL**
Set `<link rel="canonical" href="...">` to the article's final published URL under `elevenplusworks.co.uk/articles/`.

**Folder placement**
Article files live under `/articles/`. Do not place new content pages elsewhere on the site.

**Cross-links**
Add at least one link from the new article to an existing related article, and at least one link back from an existing related article to the new one. Judge "related" by topic overlap (e.g. two articles both about vocabulary strategy, or both about exam prep timing).

**Homepage guides.html update**
Add the new article to the relevant section of `guides.html` so it's discoverable from the homepage, matching the existing list format there.

**App mention**
Include a natural mention of the 11+ Words app with a link to its Play Store listing. This should read as a relevant recommendation in context, not a bolted-on advert.

## Editorial conventions (apply while writing or editing article copy)

- Call the content "articles," never "blog posts."
- Do not use "Guides" or "Blog" as a content section label (the existing `guides.html` file name is a fixed exception, not a naming precedent for new labels).
- Where relevant, argue against oversized word lists: past a certain threshold, adding more words gives a learner no real benefit. This is a deliberate editorial position, not just a stylistic choice.
- Prefer vague/qualitative phrasing over specific numbers in copy (avoid references like "word #1,500").
- No em dashes in article copy.
- Site is static HTML/CSS hosted on Cloudflare; keep implementation consistent with that (no framework-specific syntax).

## Out of scope

This skill covers implementing an already-approved article. It does not cover drafting or editing the article's content itself, that happens in chat before the GitHub issue is created.
