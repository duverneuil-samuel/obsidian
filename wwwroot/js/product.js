    const ctx = document.getElementById('priceChart').getContext('2d');
    new Chart(ctx, {
        type: 'line',
        data: {
            labels: [], 
            datasets: [{
                label: 'Prix des ventes (€)',
                data: [],
                borderColor: '#5a4b81',
                backgroundColor: 'rgba(90,75,129,0.1)',
                tension: 0.4
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: false
                }
            }
        }
    });
    document.getElementById('showMoreBtn')?.addEventListener('click', function () {
        document.querySelectorAll('.extra-offre').forEach(el => el.classList.remove('d-none'));
        this.remove();
    });