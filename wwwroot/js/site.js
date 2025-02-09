﻿//// Add event listeners to each project name
//document.addEventListener("DOMContentLoaded", function () {
//    const projectList = document.querySelectorAll(".project-name");
//    projectList.forEach(project => {
//        project.addEventListener("click", function () {
//            const projectName = this.getAttribute("data-name"); // Get the project name
//            fetchProjectDetails(projectName); // Fetch project details
//        });
//    });
//});




//// Fetch project details using Ajax
//function fetchProjectDetails(projectName) {
//    console.log("Fetching details for:", projectName);

//    // Make an Ajax request to the server
//    fetch(`/Home/GetProject?projectName=${encodeURIComponent(projectName)}`)
//        .then(response => response.json())
//        .then(data => {
//            if (data.success) {
//                // Update project details dynamically
//                document.getElementById("project-title").innerText = data.name;
//                document.getElementById("project-description").innerText = `Description: ${data.description}`;
//                document.getElementById("project-author").innerText = `Author: ${data.author}`;
//                document.getElementById("project-type").innerText = `Type: ${data.type}`;
//                document.getElementById("project-date").innerText = `Published: ${data.datePublished}`;
//            } else {
//                // Show error message
//                document.getElementById("project-title").innerText = "Error";
//                document.getElementById("project-description").innerText = data.message;
//                document.getElementById("project-author").innerText = "";
//                document.getElementById("project-type").innerText = "";
//                document.getElementById("project-date").innerText = "";
//            }
//        })
//        .catch(error => {
//            console.error("Error fetching project:", error);
//            document.getElementById("project-title").innerText = "Error";
//            document.getElementById("project-description").innerText = "An error occurred while fetching the project.";
//            document.getElementById("project-author").innerText = "";
//            document.getElementById("project-type").innerText = "";
//            document.getElementById("project-date").innerText = "";
//        });
//}

const bio = document.getElementById("bio");
const btn = document.getElementById("read-more-btn");

btn.addEventListener("click", (e) => {
    e.preventDefault();
    bio.classList.toggle("expanded");
    btn.textContent = bio.classList.contains("expanded") ? "Read Less" : "Read More";
});


// Open Card Function
function openCard(card) {
    const cards = document.querySelectorAll('.gallery-card');
    cards.forEach(c => c.classList.remove('expanded')); // Remove 'expanded' from all cards
    card.classList.add('expanded'); // Add 'expanded' to the clicked card
}

// Close Card Function
function closeCard(event) {
    event.stopPropagation(); // Prevent triggering the openCard function
    const card = event.currentTarget.closest('.gallery-card');
    card.classList.remove('expanded');
}


document.addEventListener("DOMContentLoaded", () => {
    const downloadButton = document.getElementById("downloadButton");
    const downloadMessage = document.getElementById("downloadMessage");

    downloadButton.addEventListener("click", (event) => {
        // Display the success message
        downloadMessage.textContent = "Your resume has been downloaded!";
        downloadMessage.style.display = "block";

        // Optional: Hide the message after a few seconds
        setTimeout(() => {
            downloadMessage.style.display = "none";
        }, 5000); // 5 seconds
    });
});
function showDownloadMessage() {
    // Get the message element
    const messageElement = document.getElementById("downloadMessage");

    // Set the message text
    messageElement.textContent = "Your resume has been downloaded!";

    // Show the message
    messageElement.style.display = "block";

    // Optionally, hide the message after a few seconds
    setTimeout(() => {
        messageElement.style.display = "none";
    }, 5000); // Hide the message after 5 seconds
}

function toggleLike(event) {
    event.stopPropagation(); // Prevent triggering openCard

    const likeButton = event.currentTarget;
    const heartIcon = likeButton.querySelector("i");
    const likeCount = likeButton.querySelector(".like-count");

    // Toggle the "liked" class
    likeButton.classList.toggle("liked");

    // Update like count and icon
    if (likeButton.classList.contains("liked")) {
        heartIcon.classList.remove("far");
        heartIcon.classList.add("fas");
        likeCount.textContent = parseInt(likeCount.textContent) + 1;
    } else {
        heartIcon.classList.remove("fas");
        heartIcon.classList.add("far");
        likeCount.textContent = parseInt(likeCount.textContent) - 1;
    }
}

function openCard(card) {
    const expandedCard = document.querySelector(".gallery-card.expanded");
    if (expandedCard) expandedCard.classList.remove("expanded");

    card.classList.add("expanded");
    card.scrollIntoView({ behavior: "smooth", block: "center" });
}

function closeCard(event) {
    event.stopPropagation(); // Prevent click propagation
    const card = event.target.parentElement;
    card.classList.remove("expanded");
}


