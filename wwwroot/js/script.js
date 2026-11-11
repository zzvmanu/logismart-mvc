
//VLibras aqui

const loginBtn = document.getElementById("loginBtn");
const registerBtn = document.getElementById("registerBtn");

const loginForm = document.getElementById("loginForm");
const registerForm = document.getElementById("registerForm");

const erro = document.getElementById("erro");

// Alternar abas
loginBtn.addEventListener("click", () => {
  loginForm.classList.remove("hidden");
  registerForm.classList.add("hidden");

  loginBtn.classList.add("active");
  registerBtn.classList.remove("active");

  erro.innerText = "";
});

registerBtn.addEventListener("click", () => {
  registerForm.classList.remove("hidden");
  loginForm.classList.add("hidden");

  registerBtn.classList.add("active");
  loginBtn.classList.remove("active");

  erro.innerText = "";
});

// Validação login
loginForm.addEventListener("submit", function(e) {
  const email = loginForm.email.value;
  const senha = loginForm.senha.value;

  if (!email || !senha) {
    e.preventDefault();
    erro.innerText = "Preencha todos os campos.";
  }
});

// Validação cadastro
registerForm.addEventListener("submit", function(e) {
  const senha = registerForm.senha.value;
  const confirmar = registerForm.confirmarSenha.value;

  if (senha !== confirmar) {
    e.preventDefault();
    erro.innerText = "As senhas não coincidem.";
  }
});