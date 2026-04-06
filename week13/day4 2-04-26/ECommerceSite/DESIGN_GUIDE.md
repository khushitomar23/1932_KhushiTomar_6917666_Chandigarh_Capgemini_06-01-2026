# 🎨 ECommerce Site - Design & Styling Guide

## 🌈 Color Palette (Cute Pastel Colors)

### Primary Colors
```css
--primary-pink: #FFB6D9        /* Soft, cute pink */
--primary-purple: #C5A3FF      /* Lavender purple */
--primary-blue: #A8D8FF        /* Sky blue */
--primary-peach: #FFD4A3       /* Warm peach */
--primary-mint: #A8FFD8        /* Fresh mint green */
--soft-white: #FFF9F5          /* Warm off-white */
```

### Text Colors
```css
--text-color: #6B5B7F          /* Deep purple-gray */
--accent-pink: #FF99CC         /* Brighter pink */
--accent-purple: #B880FF       /* Brighter purple */
```

### Visual Effects
```css
--shadow: 0 4px 15px rgba(196, 163, 255, 0.2)  /* Soft shadow */
```

---

## 🔤 Typography

### Google Fonts Used

#### 1. **Caveat** (Brand/Logo)
```css
font-family: 'Caveat', cursive;
font-size: 2rem - 3rem;
font-weight: 700;
/* Cute handwriting style for headers */
```
**Used for**: 
- Navbar brand name
- Hero titles
- Card titles

**Preview**: ✨ ECommerce Shop ✨

#### 2. **Dancing Script** (Headings)
```css
font-family: 'Dancing Script', cursive;
font-size: 1.3rem - 2.5rem;
font-weight: 400 - 700;
/* Elegant calligraphy for section headers */
```
**Used for**:
- Product names
- Section headings
- Special typography

**Preview**: Our Featured Products

#### 3. **Quicksand** (Body Text)
```css
font-family: 'Quicksand', sans-serif;
font-size: 0.9rem - 1.2rem;
font-weight: 300 - 700;
/* Clean, rounded sans-serif for readability */
```
**Used for**:
- Product descriptions
- Form labels
- General text
- Navigation

---

## 🎯 Component Styling

### Cards
```css
border: none;
border-radius: 15px;                    /* Rounded corners */
box-shadow: 0 6px 20px rgba(...);      /* Soft shadow */
border-top: 5px solid var(--primary-pink);  /* Pink accent line */
transition: transform 0.3s ease;        /* Smooth animation */

/* On hover */
transform: translateY(-5px);             /* Float up */
box-shadow: 0 12px 30px rgba(...);      /* Bigger shadow */
```

### Buttons
```css
border: none;
border-radius: 25px;                    /* Very rounded */
padding: 0.7rem 1.5rem;
font-weight: 600;
text-transform: uppercase;              /* All caps */
letter-spacing: 1px;                    /* Spaced letters */
transition: all 0.3s ease;

/* Primary Button */
background: linear-gradient(90deg, var(--primary-pink) 0%, var(--accent-pink) 100%);
color: white;

/* On hover */
transform: scale(1.05);                 /* Slight zoom */
```

### Forms
```css
border: 2px solid var(--primary-pink);
border-radius: 10px;
padding: 0.7rem 1rem;

/* On focus */
border-color: var(--primary-purple);
box-shadow: 0 0 0 0.2rem rgba(197, 163, 255, 0.25);
background: #FAFAFA;
```

### Product Grid
```css
display: grid;
grid-template-columns: repeat(auto-fill, minmax(280px, 1fr));
gap: 2rem;

/* Responsive */
@media (max-width: 768px) {
    grid-template-columns: repeat(auto-fill, minmax(200px, 1fr));
    gap: 1rem;
}
```

---

## ✨ Special Effects

### Floating Animation
```css
@keyframes float {
  0%, 100% { transform: translateY(0px); }
  50% { transform: translateY(-10px); }
}

.hero {
    animation: float 3s ease-in-out infinite;
}
```
Used on: Hero section (smooth up-down motion)

### Rotating Loader
```css
@keyframes spin {
    to { transform: rotate(360deg); }
}

.loading {
    border: 3px solid var(--primary-pink);
    border-top-color: transparent;
    animation: spin 1s ease-in-out infinite;
}
```
Used on: Loading indicators

### Hover Underline
```css
.navbar-nav .nav-link:hover::after {
    content: '';
    position: absolute;
    bottom: -5px;
    left: 0;
    right: 0;
    height: 3px;
    background: white;
    border-radius: 2px;
}
```
Used on: Navigation links

### Gradients
```css
/* Master background */
background: linear-gradient(135deg, #FFF9F5 0%, #FFF0F5 100%);

/* Navigation bar */
background: linear-gradient(90deg, #FFB6D9 0%, #C5A3FF 100%);

/* Buttons */
background: linear-gradient(90deg, #FFB6D9 0%, #FF99CC 100%);

/* Product image placeholder */
background: linear-gradient(135deg, #FFB6D9 0%, #C5A3FF 100%);
```

---

## 🎨 Component Examples

### Hero Section
```html
<div class="hero">
    <h1>✨ Welcome to Our Cute Shop ✨</h1>
    <p>Discover amazing products handpicked just for you!</p>
    <a href="#" class="btn btn-primary">Shop Now</a>
</div>
```

**Styling**:
- Background: Pink to purple gradient
- Text: White with shadow
- Animation: Floating effect
- Padding: 4rem 2rem
- Border radius: 20px

### Product Card
```html
<div class="product-card">
    <div style="background: linear-gradient(...)">
        🛍️  <!-- Emoji as placeholder -->
    </div>
    <div class="product-card-body">
        <h5 class="product-name">Product Name</h5>
        <p class="product-price">Rs. 599.99</p>
        <span class="badge-tag">Category</span>
    </div>
</div>
```

**Styling**:
- Border Top: 5px pink line
- Hover: Float up with bigger shadow
- Border Radius: 15px
- Shadow: Soft purple shadow

### Badges/Tags
```html
<span class="badge-tag">Category Name</span>
```

**Styling**:
- Background: Peach to golden gradient
- Color: White text
- Border radius: 15px (pill-shaped)
- Padding: 0.3rem 0.8rem

### Buttons
```html
<!-- Primary (Pink) -->
<button class="btn btn-primary">Action</button>

<!-- Secondary (Purple) -->
<button class="btn btn-secondary">Secondary</button>

<!-- Success (Mint) -->
<button class="btn btn-success">Success</button>

<!-- Outline -->
<button class="btn btn-outline">Outline</button>
```

### Alerts
```html
<div class="alert alert-success">Success message</div>
<div class="alert alert-danger">Error message</div>
<div class="alert alert-info">Info message</div>
```

**Alert Colors**:
- Success: Mint green background, left border
- Danger: Pink background, left border
- Info: Blue background, left border

---

## 📱 Responsive Design

### Breakpoints
```css
/* Mobile First */
.products-grid {
    grid-template-columns: 1fr;  /* 1 column on mobile */
}

/* Tablet */
@media (min-width: 768px) {
    .products-grid {
        grid-template-columns: repeat(auto-fill, minmax(280px, 1fr));
    }
}

/* Desktop */
@media (min-width: 1024px) {
    .products-grid {
        grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
        gap: 2.5rem;
    }
}
```

### Layout Adaptations
```css
/* Navigation */
@media (max-width: 768px) {
    nav .navbar-brand { font-size: 1.5rem; }
    .navbar-nav .nav-link { font-size: 0.95rem; }
}

/* Hero */
@media (max-width: 768px) {
    .hero h1 { font-size: 2rem; }  /* 3rem on desktop */
}

/* Product Grid */
@media (max-width: 768px) {
    .products-grid {
        grid-template-columns: repeat(auto-fill, minmax(200px, 1fr));
        gap: 1rem;
    }
}
```

---

## 🌙 Dark Mode Consideration

Currently using light theme. Dark mode can be added with CSS variables:

```css
:root {
    --bg-primary: #FFF9F5;      /* Light */
    --text-primary: #6B5B7F;    /* Dark text */
}

@media (prefers-color-scheme: dark) {
    :root {
        --bg-primary: #1a1625;   /* Dark */
        --text-primary: #f5f5f5; /* Light text */
    }
}
```

---

## 📐 Spacing & Sizing

### Padding
```css
/* Cards */
padding: 1.5rem;

/* Sections */
padding: 2rem;  /* or 4rem for hero */

/* Forms */
padding: 0.7rem 1rem;  /* input */
```

### Margins
```css
/* Between items */
margin-bottom: 2rem;

/* Cards */
margin-bottom: 2rem;

/* Section title */
margin-bottom: 2rem;
```

### Border Radius
```css
Regular cards: 15px
Forms: 10px
Buttons: 25px (pill-shaped)
Badges: 15px (pill-shaped)
```

---

## 🎯 Design Philosophy

### Core Principles
1. **Minimal** - Clean, uncluttered layout
2. **Cute** - Pastel colors, rounded corners, friendly typography
3. **Responsive** - Works on all devices
4. **Accessible** - Good contrast, readable fonts
5. **Fast** - Smooth animations, no heavy assets
6. **Modern** - Current web design trends

### Color Psychology
- **Pink**: Cute, friendly, approachable
- **Purple**: Elegant, creative, calm
- **Blue**: Trust, stability, peaceful
- **Peach**: Warm, welcoming, gentle
- **Mint**: Fresh, clean, energetic

---

## 🔄 Customization Guide

### Change Primary Color
```css
/* Replace all instances of primary-pink with your color */
--primary-pink: #YOUR_COLOR;

/* Buttons, cards, accents automatically update */
```

### Change Fonts
```css
/* Import new font from Google Fonts */
@import url('https://fonts.googleapis.com/css2?family=NEW_FONT:wght@400;700&display=swap');

/* Update font-family rules */
.heading { font-family: 'NEW_FONT', cursive; }
```

### Adjust Shadows
```css
/* Make shadows more prominent */
box-shadow: 0 8px 25px rgba(196, 163, 255, 0.3);

/* Make shadows subtle */
box-shadow: 0 2px 8px rgba(196, 163, 255, 0.1);
```

---

**Design by: Cute & Minimal Philosophy** ✨

**Last Updated**: April 2026
