
//const [current, imgs, opacity] = [document.getElementById('current'), document.querySelectorAll('.imgs img'), 0.6];

//imgs[0].style.opacity = opacity;

//imgs.forEach(img => img.addEventListener('click', imgClick));

//function imgClick(e) {
//    imgs.forEach(img => (img.style.opacity = 1));

//    current.src = e.target.src;

//    current.classList.add('fade-in');

//    setTimeout(() => current.classList.remove('fade-in'), 500);

//    e.target.style.opacity = opacity;
//}

$(function () {
    $("#txtSearch").autocomplete({
        source: "/Home/GetAlbumTitles",
        minLength: 0,
        classes: {
            "ui-autocomplete": "highlight"
        }
    });
});
