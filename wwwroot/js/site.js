document.addEventListener('DOMContentLoaded', () => {
    document.body.classList.add('page-loaded');

    const perspectiveCards = document.querySelectorAll('.perspective-card');
    perspectiveCards.forEach(card => {
        card.addEventListener('mousemove', (e) => {
            const rect = card.getBoundingClientRect();
            const x = e.clientX - rect.left;
            const y = e.clientY - rect.top;

            const centerX = rect.width / 2;
            const centerY = rect.height / 2;

            const rotateX = (centerY - y) / 10;
            const rotateY = (x - centerX) / 10;

            card.style.transform = `perspective(1000px) rotateX(${rotateX}deg) rotateY(${rotateY}deg) scale(1.02)`;
        });

        card.addEventListener('mouseleave', () => {
            card.style.transform = `perspective(1000px) rotateX(0deg) rotateY(-15deg)`;
            if (window.innerWidth <= 1024) {
                card.style.transform = `perspective(1000px) rotateX(0deg) rotateY(0deg)`;
            }
        });
    });

    const inputs = document.querySelectorAll('.form-control');
    inputs.forEach(input => {
        input.addEventListener('focus', () => {
            input.parentElement.classList.add('input-focused');
        });
        input.addEventListener('blur', () => {
            input.parentElement.classList.remove('input-focused');
        });
    });

    document.querySelectorAll('a').forEach(link => {
        if (link.hostname === window.location.hostname &&
            !link.getAttribute('href').startsWith('#') &&
            !link.getAttribute('target')) {
            link.addEventListener('click', (e) => {
                const href = link.getAttribute('href');
                if (href && href !== '#' && !href.includes('logout')) {
                    e.preventDefault();
                    document.body.style.opacity = '0';
                    document.body.style.transform = 'scale(0.98)';
                    document.body.style.transition = 'all 0.3s ease-out';
                    setTimeout(() => {
                        window.location.href = href;
                    }, 300);
                }
            });
        }
    });
});
