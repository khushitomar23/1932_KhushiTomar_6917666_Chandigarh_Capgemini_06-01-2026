const questions = [
    {
        question: "Which language is used for web development?",
        options: ["Python", "C++", "HTML", "Java"],
        answer: 2
    },
    {
        question: "Which company developed Java?",
        options: ["Microsoft", "Sun Microsystems", "Google", "Apple"],
        answer: 1
    },
    {
        question: "Which keyword is used to declare a variable in JavaScript?",
        options: ["int", "var", "string", "define"],
        answer: 1
    }
];

let currentQuestion = 0;
let score = 0;
let timer;
let timeLeft = 10;

const questionElement = document.getElementById("question");
const optionButtons = document.querySelectorAll(".option-btn");
const nextBtn = document.getElementById("nextBtn");
const resultElement = document.getElementById("result");
const timeDisplay = document.getElementById("time");

function loadQuestion() {
    resetState();
    startTimer();

    let q = questions[currentQuestion];
    questionElement.textContent = q.question;

    optionButtons.forEach((btn, index) => {
        btn.textContent = q.options[index];
        btn.onclick = () => selectAnswer(index);
    });
}

function resetState() {
    nextBtn.style.display = "none";
    optionButtons.forEach(btn => {
        btn.classList.remove("correct", "incorrect");
        btn.disabled = false;
    });
}

function selectAnswer(index) {
    clearInterval(timer);
    let correctIndex = questions[currentQuestion].answer;

    optionButtons.forEach(btn => btn.disabled = true);

    if (index === correctIndex) {
        optionButtons[index].classList.add("correct");
        score++;
    } else {
        optionButtons[index].classList.add("incorrect");
        optionButtons[correctIndex].classList.add("correct");
    }

    nextBtn.style.display = "block";
}

nextBtn.addEventListener("click", () => {
    currentQuestion++;
    if (currentQuestion < questions.length) {
        loadQuestion();
    } else {
        showResult();
    }
});

function showResult() {
    questionElement.textContent = "";
    document.querySelector(".options").style.display = "none";
    nextBtn.style.display = "none";
    document.getElementById("timer").style.display = "none";
    resultElement.textContent = `Your Score: ${score} / ${questions.length}`;
}

function startTimer() {
    timeLeft = 10;
    timeDisplay.textContent = timeLeft;

    timer = setInterval(() => {
        timeLeft--;
        timeDisplay.textContent = timeLeft;

        if (timeLeft === 0) {
            clearInterval(timer);
            nextBtn.style.display = "block";
            optionButtons.forEach(btn => btn.disabled = true);
        }
    }, 1000);
}

loadQuestion();