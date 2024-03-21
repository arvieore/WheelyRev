function showDescription(productId) {
    var preview = document.getElementById('preview-' + productId);
    if (preview) {
        preview.classList.add('active');
        document.querySelector('.products-preview').style.display = 'flex';
    }
}

function hideDescription(productId) {
    var preview = document.getElementById('preview-' + productId);
    if (preview) {
        preview.classList.remove('active');
        document.querySelector('.products-preview').style.display = 'none';
    }
}

function closeLightbox(productId) {
    var preview = document.getElementById('preview-' + productId);
    if (preview) {
        preview.classList.remove('active');
        document.querySelector('.products-preview').style.display = 'none';
    }
}