// Email validation
function isValidEmail(email) {
    let regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return regex.test(email);
}

// Register
document.getElementById("registerForm").addEventListener("submit", function(e) {
    e.preventDefault();

    let username = document.getElementById("regUsername").value;
    let email = document.getElementById("regEmail").value;
    let password = document.getElementById("regPassword").value;
    let confirmPassword = document.getElementById("regConfirmPassword").value;

    if (!isValidEmail(email)) {
        alert("Invalid email format!");
        return;
    }

    if (password.length < 6) {
        alert("Password must be at least 6 characters long!");
        return;
    }

    if (password !== confirmPassword) {
        alert("Passwords do not match!");
        return;
    }

    let user = {
        username: username,
        email: email,
        password: password
    };

    localStorage.setItem(email, JSON.stringify(user));

    alert("Registration successful!");
    document.getElementById("registerForm").reset();
});

// Login
document.getElementById("loginForm").addEventListener("submit", function(e) {
    e.preventDefault();

    let email = document.getElementById("loginEmail").value;
    let password = document.getElementById("loginPassword").value;

    let storedUser = localStorage.getItem(email);

    if (storedUser === null) {
        alert("User not found!");
        return;
    }

    let user = JSON.parse(storedUser);

    if (user.password === password) {
        alert("Login successful! Welcome " + user.username);
    } else {
        alert("Incorrect password!");
    }

    document.getElementById("loginForm").reset();
});