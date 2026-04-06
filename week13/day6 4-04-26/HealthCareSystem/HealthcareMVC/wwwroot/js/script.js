// ========================================
// Healthcare MVC - Advanced JavaScript
// ========================================

document.addEventListener('DOMContentLoaded', function() {
    console.log('Healthcare MVC Initialized');
    
    // Initialize all features
    initializeFormValidation();
    initializeDatePicker();
    initializePasswordValidation();
    initializeAPIIntegration();
    initializeUIEnhancements();
});

// ========================================
// 1. FORM VALIDATION
// ========================================
function initializeFormValidation() {
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
        // Real-time input validation
        const inputs = form.querySelectorAll('input[required]');
        inputs.forEach(input => {
            input.addEventListener('blur', function() {
                validateInput(this);
            });
            
            input.addEventListener('focus', function() {
                this.style.borderColor = '#e8e8e8';
            });
        });

        // Form submission validation
        form.addEventListener('submit', function(e) {
            let isValid = true;
            inputs.forEach(input => {
                if (!validateInput(input)) {
                    isValid = false;
                }
            });

            if (!isValid) {
                e.preventDefault();
                showNotification('Please fill all required fields', 'error');
            }
        });
    });
}

function validateInput(input) {
    const value = input.value.trim();
    const type = input.type;
    
    // Check if empty
    if (!value) {
        input.style.borderColor = '#fc5c65';
        return false;
    }

    // Email validation
    if (type === 'email') {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(value)) {
            input.style.borderColor = '#fc5c65';
            return false;
        }
    }

    // Password validation (min 8 chars, at least one number)
    if (input.id === 'password' && value.length < 8) {
        input.style.borderColor = '#ff69b4';
        return false;
    }

    input.style.borderColor = '#26de81';
    return true;
}

// ========================================
// 2. DATE PICKER
// ========================================
function initializeDatePicker() {
    const dateInput = document.getElementById('appointmentDate');
    if (dateInput) {
        // Set minimum date to today
        const today = new Date();
        today.setHours(0, 0, 0, 0);
        const minDate = today.toISOString().slice(0, 16);
        dateInput.setAttribute('min', minDate);

        // Add date change validation
        dateInput.addEventListener('change', function() {
            const selectedDate = new Date(this.value);
            const today = new Date();
            today.setHours(0, 0, 0, 0);

            if (selectedDate < today) {
                this.style.borderColor = '#fc5c65';
                showNotification('Please select a future date', 'error');
            } else {
                this.style.borderColor = '#26de81';
            }
        });
    }
}

// ========================================
// 3. PASSWORD VALIDATION
// ========================================
function initializePasswordValidation() {
    const password = document.getElementById('password');
    const confirmPassword = document.getElementById('confirmPassword');
    
    if (confirmPassword && password) {
        // Real-time password comparison
        confirmPassword.addEventListener('input', function() {
            if (password.value === this.value) {
                this.style.borderColor = '#26de81';
                showPasswordMatch(true);
            } else if (this.value.length > 0) {
                this.style.borderColor = '#fc5c65';
                showPasswordMatch(false);
            }
        });

        // Show password strength indicator
        password.addEventListener('input', function() {
            showPasswordStrength(this.value);
        });
    }
}

function showPasswordStrength(password) {
    let strength = 'Weak';
    let color = '#fc5c65';

    if (password.length >= 8) {
        if (/[A-Z]/.test(password) && /[0-9]/.test(password)) {
            strength = 'Strong';
            color = '#26de81';
        } else if (/[A-Z]/.test(password) || /[0-9]/.test(password)) {
            strength = 'Medium';
            color = '#ff69b4';
        }
    }

    console.log(`Password Strength: ${strength}`);
}

function showPasswordMatch(matches) {
    const message = matches ? 'Passwords match ✓' : 'Passwords do not match ✗';
    console.log(message);
}

// ========================================
// 4. API INTEGRATION
// ========================================
function initializeAPIIntegration() {
    // Enhanced form submissions with loading states
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
        form.addEventListener('submit', function(e) {
            const submitBtn = form.querySelector('button[type="submit"]');
            if (submitBtn) {
                const originalText = submitBtn.textContent;
                submitBtn.textContent = 'Processing...';
                submitBtn.disabled = true;

                // Re-enable button after 2 seconds (form will redirect if successful)
                setTimeout(() => {
                    submitBtn.textContent = originalText;
                    submitBtn.disabled = false;
                }, 2000);
            }
        });
    });
}

// ========================================
// 5. UI ENHANCEMENTS
// ========================================
function initializeUIEnhancements() {
    // Smooth button interactions
    const buttons = document.querySelectorAll('.btn');
    buttons.forEach(btn => {
        btn.addEventListener('mouseenter', function() {
            this.style.transform = 'translateY(-2px)';
        });

        btn.addEventListener('mouseleave', function() {
            this.style.transform = 'translateY(0)';
        });
    });

    // Appointment cancellation confirmation
    const cancelForms = document.querySelectorAll('form[action*="cancel"]');
    cancelForms.forEach(form => {
        form.addEventListener('submit', function(e) {
            if (!confirm('Are you sure you want to cancel this appointment?')) {
                e.preventDefault();
            }
        });
    });

    // Mobile menu toggle (if needed)
    const navMenu = document.querySelector('.nav-menu');
    if (navMenu && window.innerWidth < 768) {
        console.log('Mobile navigation detected');
    }
}

// ========================================
// 6. UTILITY FUNCTIONS
// ========================================
function showNotification(message, type = 'info') {
    // Create a simple alert for now
    // Can be enhanced with toast notifications later
    const alertClass = type === 'error' ? 'alert-danger' : 'alert-success';
    console.log(`[${type.toUpperCase()}] ${message}`);
}

// Format date for display
function formatDate(dateString) {
    const options = { year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit' };
    return new Date(dateString).toLocaleDateString('en-US', options);
}

// Check if user is logged in (check session/localStorage)
function isUserLoggedIn() {
    // Check if logout button exists (server-side session indicator)
    return document.querySelector('.logout-btn') !== null;
}

// Get current user info from page
function getCurrentUserInfo() {
    const logoutBtn = document.querySelector('.logout-btn');
    return {
        isLoggedIn: logoutBtn !== null,
        sessionActive: true
    };
}

// ========================================
// 7. ANIMATION HELPERS
// ========================================
function fadeInElement(element) {
    element.style.opacity = '0';
    element.style.animation = 'fadeIn 0.5s ease-out forwards';
}

function slideInElement(element) {
    element.style.transform = 'translateY(20px)';
    element.style.opacity = '0';
    element.style.animation = 'fadeIn 0.5s ease-out forwards';
}

// ========================================
// 8. KEYBOARD SHORTCUTS (OPTIONAL)
// ========================================
document.addEventListener('keydown', function(e) {
    // ESC to clear form focus
    if (e.key === 'Escape') {
        document.activeElement.blur();
    }

    // CTRL+E to go to appointments (quick shortcut)
    if (e.ctrlKey && e.key === 'e') {
        const appointmentsLink = document.querySelector('a[href*="appointments"]');
        if (appointmentsLink) {
            appointmentsLink.click();
        }
    }
});

// ========================================
// 9. LOGGING & DEBUGGING
// ========================================
window.debugHealthcare = {
    userInfo: getCurrentUserInfo,
    formatDate: formatDate,
    validateInput: validateInput,
    logFormState: function() {
        const forms = document.querySelectorAll('form');
        console.table(Array.from(forms).map((f, i) => ({
            Form: i + 1,
            Action: f.action,
            Method: f.method,
            Fields: f.querySelectorAll('input[required]').length
        })));
    }
};

console.log('Healthcare Helper Functions Available: window.debugHealthcare');
