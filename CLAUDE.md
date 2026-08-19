# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Static marketing landing page for "11+ Words", a free mobile app (Google Play) that helps children build vocabulary for the UK 11+ exam. The site is plain HTML/CSS/vanilla JS — no build tools, package manager, or framework.

## Development

- Open `src/index.html` directly in a browser to preview (or use a simple local server / Live Server extension).
- No build, lint, or test commands exist — edit HTML/CSS directly and verify in-browser.

## Structure

- `src/index.html` — the live home page. Single-page layout with sections: hero, "Why Vocabulary Matters", "Solution", "Features", "Free to Use", FAQ (with inline `toggleFaq` JS for accordion behavior), final CTA, footer.
- `src/guides.html` — guides index; links to the guide pages in `src/articles/`.
- `src/articles/500-most-important-words.html` — the "500 Most Important Words" vocabulary guide (three word tables, 100/150/250 rows). Generated from `src/articles/500_most_important_words.pdf`; sits one level down, so all assets are referenced via `../`.
- `src/articles/` — the guide pages plus the source PDFs they are built from.
- `src/styles.css` — styles for every page on the site, not just `index.html`.
- `src/index-example.html` / `src/styles-example.css` — example/reference variant, not the live page.
- `src/imgs/` — images (app icon, phone mockups at multiple resolutions, decorative graphics).
- `src/THEMES-README.md` — describes alternate color themes (Coral, Ocean Blue, Forest Green) that were explored; only the original purple theme (`index.html` + `styles.css`) is currently live. Theme-specific files referenced there (`index-theme1.html`, etc.) may not all be present.

## Design

The palette, type scale, and component specs are recorded in a Claude Design design-system project named **"11+ Words Design System"** (`projectId c57c53a1-db2c-49bf-af39-739b2cf3d6bc`), readable and writable via the `DesignSync` tool. It holds `tokens/tokens.css` (custom properties), swatch/type/component preview pages, and a README of the conventions.

`src/styles.css` does **not** consume those tokens — every colour is still hard-coded. So the design project is a *record*, not a dependency: if you change colours in the CSS, push the same change to the project or the two drift.

Conventions to preserve:

- **One font family:** Inter, loaded via `@import` and set once on `body`. Weights 400 / 600 / 700 only.
- **Green means download.** `#2F9434` (hover `#2E7D32`) is used for the Play Store button and nothing else; every other interactive pill is coral.
- **Coral has three steps:** `#C8564F` page titles (`.hero h1`, `.article-header h1`), `#F3666B` section headings and CTA panels, `#F68C90` only as the far end of `linear-gradient(135deg, #F3666B, #F68C90)`.
- **Amber means "extra resource."** `#C98A18` (hover/accent `#A8710F`) on a `#FFF6E5` panel with a `rgba(201, 138, 24, 0.28)` border — the third and last reserved colour, for downloadable extras that sit beside the main content (the printable PDF callout, `.pdf-panel--amber`). Reuse it for other downloads/resources rather than inventing a new accent; do not use it for navigation or the app CTA. Button text is white, `strong` inside the panel is `#A8710F`, body copy stays `#420002`.
- **Text:** `#420002` headings/emphasis, `#BA5B5B` body copy.
- **Surfaces:** page gradient `#FFFAFA → #F4F4F4`, `#FFFFFF` cards/tables, `#FFF0F0` tint for table headers and pills; borders are `rgba(200, 86, 79, …)`.
- **Radii:** pills 30px, cards 16px, panels 20px, table containers 12px.
- **Breakpoints:** 768px (grids collapse to one column, `h1` → 2.2rem), 600px (header nav, table type), 480px (`h1` → 1.8rem, tighter padding). A rule added for one breakpoint usually needs its siblings — see `.hero h1` and `.article-header h1`, which step together.

## Notes

- Several sections ("How It Works", "Benefits") are commented out in `index.html` — check before assuming a section is missing entirely.
- The Google Play download link (`https://play.google.com/store/apps/details?id=com.mindthatbit.x11pluswords`) appears in multiple CTAs; keep these consistent if updated.
- Images are served at multiple resolutions via `srcset` (e.g. `phone_561.png` 1x / `phone_1000.png` 2x) — provide both sizes when adding similar responsive images.
- `.content-card *` in `styles.css` sets `border`/`box-shadow`/`background-image` to `none !important`, which silently strips borders from anything nested inside a content card — don't put tables or bordered components there.
- The downloadable-resource callout is `.pdf-panel` / `.pdf-panel-text` / `.pdf-link` in `styles.css` (amber variant `.pdf-panel--amber`). It's a flex row that centres and stacks below 600px — reuse the markup as-is for any new download panel; only the colour modifier should change.
- To extract text from a PDF in `src/articles/`, use `pdftotext -table`. Plain `-layout` mis-shifts every table row whose cell wraps to a second line.
