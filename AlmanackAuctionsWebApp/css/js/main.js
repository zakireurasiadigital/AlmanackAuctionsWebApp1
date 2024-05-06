document.addEventListener("DOMContentLoaded", function () {
  window.addEventListener("scroll", function () {
    if (window.scrollY > 50) {
      document.getElementById("navbar_top").classList.add("fixed-top");
      // add padding top to show content behind navbar
      navbar_height = document.querySelector(".navbar").offsetHeight;
      document.body.style.paddingTop = navbar_height + "px";
    } else {
      document.getElementById("navbar_top").classList.remove("fixed-top");
      // remove padding top from body
      document.body.style.paddingTop = "0";
    }
  });
});

var slider = document.getElementById("myRange");
var output = document.getElementById("demo");
// output.innerHTML = slider.value; // Display the default slider value

// Update the current slider value (each time you drag the slider handle)

let choice = -1;

$("#yes").on("click", function () {
  $(this).addClass("activeButton");
  $("#no").removeClass("activeButton");
  choice = 1;
});

$("#no").on("click", function () {
  $(this).addClass("activeButton");
  $("#yes").removeClass("activeButton");
  choice = 0;
});

// Detect Screen Size
let screenSize = window.innerWidth;
window.addEventListener("resize", function (e) {
screenSize = window.innerWidth;
});
 
if (screenSize < 1199) {
// Menu Click Event
let trigger = $(".navbar-toggler");
let dropdown = $("#navbarNav");
if (trigger || dropdown) {
trigger.each(function () {
$(this).on("click", function (e) {
e.stopPropagation();
});
});
dropdown.each(function () {
$(this).on("click", function (e) {
e.stopPropagation();
});
});
$(document).on("click", function () {
dropdown.removeClass("show");
trigger.removeClass("collapsed");
});
}
}