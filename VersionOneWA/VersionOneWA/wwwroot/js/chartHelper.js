window.renderPieChart = (canvasRef, done, remaining) => {
    const ctx = canvasRef.getContext('2d');
    new Chart(ctx, {
        type: 'pie',
        data: {
            labels: ['Done Tasks', 'Remaining Tasks'],
            datasets: [{
                data: [done, remaining],
                backgroundColor: ['#28a745', '#ffc107'],
                borderColor: '#fff',
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'bottom'
                }
            }
        }
    });
};
