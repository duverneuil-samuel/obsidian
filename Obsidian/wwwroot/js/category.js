document.addEventListener('DOMContentLoaded', () => {
    initSortDropdown();
    initProductNavigation();
});

// Gestion du dropdown
function initSortDropdown() {
    const sortButton = document.querySelector('.sort-button');
    const dropdown = document.getElementById('sortDropdown');
    if (!sortButton || !dropdown) return;

    // Toggle dropdown
    sortButton.addEventListener('click', e => {
        e.stopPropagation();
        dropdown.classList.toggle('show');
    });

    // Fermer au clic extérieur
    document.addEventListener('click', () => dropdown.classList.remove('show'));

    // Choix du critère de tri
    dropdown.addEventListener('click', e => {
        if (e.target.matches('a[data-sort]')) {
            e.preventDefault();
            sortProducts(e.target.dataset.sort);
            dropdown.classList.remove('show');
        }
        e.stopPropagation();
    });
}

// Navigation vers la page produit (event delegation)
function initProductNavigation() {
    const container = document.getElementById('products-container');
    if (!container) return;

    container.addEventListener('click', e => {
        const card = e.target.closest('.product-card');
        if (card) {
            const id = card.dataset.productId;
            if (id) window.location.href = `/Product/Detail/${id}`;
        }
    });
}

// Tri des produits
function sortProducts(criteria) {
    const container = document.getElementById('products-container');
    const cards = [...container.getElementsByClassName('product-card')];

    const sortFns = {
        'alpha-asc': (a, b) => a.querySelector('.product-name').textContent.localeCompare(b.querySelector('.product-name').textContent),
        'alpha-desc': (a, b) => b.querySelector('.product-name').textContent.localeCompare(a.querySelector('.product-name').textContent),
        'price-asc': (a, b) => parseFloat(a.querySelector('.product-price').textContent) - parseFloat(b.querySelector('.product-price').textContent),
        'price-desc': (a, b) => parseFloat(b.querySelector('.product-price').textContent) - parseFloat(a.querySelector('.product-price').textContent)
    };

    cards.sort(sortFns[criteria] || (() => 0));
    container.innerHTML = '';
    container.append(...cards);
}
