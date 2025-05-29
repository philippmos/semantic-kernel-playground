db = db.getSiblingDB("taiste");

db.createCollection("cooking_recipes");

db.cooking_recipes.insertMany([
    {
        id: UUID(),
        name: "Spaghetti Carbonara",
        ingredients: [
            "200g spaghetti",
            "100g pancetta",
            "2 large eggs",
            "50g pecorino cheese",
            "50g parmesan",
            "Black pepper",
            "Salt"
        ],
        instructions: [
            "Cook spaghetti in salted boiling water.",
            "Fry pancetta until crisp.",
            "Beat eggs and mix with cheeses.",
            "Drain pasta and combine with pancetta.",
            "Remove from heat, add egg and cheese mixture.",
            "Stir quickly and serve with pepper."
        ],
        servings: 2,
        cuisine: "Italian",
        difficulty: 1
    },
    {
        id: UUID(),
        name: "Chicken Tikka Masala",
        ingredients: [
            "500g chicken breast",
            "150g yogurt",
            "2 tbsp tikka masala paste",
            "1 onion",
            "400g chopped tomatoes",
            "100ml cream",
            "2 cloves garlic",
            "1 inch ginger",
            "Salt",
            "Coriander"
        ],
        instructions: [
            "Marinate chicken in yogurt and tikka masala paste.",
            "Grill or fry chicken pieces.",
            "Fry onion, garlic, and ginger.",
            "Add tomatoes and simmer.",
            "Add chicken and cream, cook until thickened.",
            "Garnish with coriander and serve."
        ],
        servings: 4,
        cuisine: "Indian",
        difficulty: 2
    },
    {
        id: UUID(),
        name: "Vegetable Stir Fry",
        ingredients: [
            "1 broccoli head",
            "1 red bell pepper",
            "1 carrot",
            "100g snap peas",
            "2 tbsp soy sauce",
            "1 tbsp sesame oil",
            "2 cloves garlic",
            "1 tsp ginger",
            "Sesame seeds"
        ],
        instructions: [
            "Chop all vegetables.",
            "Heat sesame oil in a wok.",
            "Add garlic and ginger, stir fry briefly.",
            "Add vegetables and stir fry until crisp-tender.",
            "Add soy sauce and toss.",
            "Serve sprinkled with sesame seeds."
        ],
        servings: 2,
        cuisine: "Asian",
        difficulty: 2
    }
]);