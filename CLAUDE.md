# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Static marketing landing page for "11+ Words", a free mobile app (Google Play) that helps children build vocabulary for the UK 11+ exam. The site is plain HTML/CSS/vanilla JS — no build tools, package manager, or framework.

## Development

- Open `src/index.html` directly in a browser to preview (or use a simple local server / Live Server extension).
- No build, lint, or test commands exist — edit HTML/CSS directly and verify in-browser.

## Structure

- `src/index.html` — the live page (purple gradient theme). Single-page layout with sections: hero, "Why Vocabulary Matters", "Solution", "Features", "Free to Use", FAQ (with inline `toggleFaq` JS for accordion behavior), final CTA, footer.
- `src/styles.css` — styles for `index.html`.
- `src/index-example.html` / `src/styles-example.css` — example/reference variant, not the live page.
- `src/imgs/` — images (app icon, phone mockups at multiple resolutions, decorative graphics).
- `src/THEMES-README.md` — describes alternate color themes (Coral, Ocean Blue, Forest Green) that were explored; only the original purple theme (`index.html` + `styles.css`) is currently live. Theme-specific files referenced there (`index-theme1.html`, etc.) may not all be present.

## Notes

- Several sections ("How It Works", "Benefits") are commented out in `index.html` — check before assuming a section is missing entirely.
- The Google Play download link (`https://play.google.com/store/apps/details?id=com.mindthatbit.x11pluswords`) appears in multiple CTAs; keep these consistent if updated.
- Images are served at multiple resolutions via `srcset` (e.g. `phone_561.png` 1x / `phone_1000.png` 2x) — provide both sizes when adding similar responsive images.
