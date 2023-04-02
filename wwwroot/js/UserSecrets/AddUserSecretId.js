window.onload = function () {
    $('.rain').empty()

    var vertLocation = 0, horLocation = 0, vertLocationIncrement = 0, horLocationIncrement = 0;
    var animDelay = 0, animDuration = 0;
    var currentDrop;

    while (horLocation < 100) {
        //Random increment between 1 and 5
        horLocationIncrement = Math.floor(Math.random() * (5 -1) + 1)
        horLocation += horLocationIncrement;
        // Random increment between 1 and 10
        vertLocationIncrement = Math.floor(Math.random() * (10 - 1) + 1);
        vertLocation = 100 + vertLocationIncrement;

        animDelay = Math.random();
        animDuration = 0.4 + (Math.random() * (99 - 1) + 1) / 1000;

        currentDrop = document.createElement("div");
            currentDrop.classList.add("drop");
            currentDrop.style.left = horLocation + "%";
            currentDrop.style.bottom = vertLocation + "%";
            currentDrop.style.animationDelay = animDelay + "s";
            currentDrop.style.animationDuration = animDuration + "s";

        currentStem = document.createElement("div");
            currentStem.classList.add("stem");
            currentStem.animationDelay = animDelay + "s";
            currentStem.animDuration = animDuration + "s";

        currentDrop.appendChild(currentStem);

        currentSplash = document.createElement("div");
            currentSplash.classList.add("splash")
            currentSplash.animationDelay = animDelay + "s";
            currentSplash.animDuration = animDuration + "s";

        currentDrop.appendChild(currentSplash);

        document.getElementById("RainDrops").appendChild(currentDrop);
    }
}

divRain();