const currentDate = document.querySelector(".current-date");
daysTag = document.querySelector(".days");
prevNextIcon = document.querySelectorAll(".icons button");

// DATAS
let date = new Date(),
  currYear = date.getFullYear(),
  currMonth = date.getMonth();

let data = new Date();
currDate = data.getDate();

// LISTA DOS MESES PARA CONVERSÃO DE INT PARA STRING
const months = [
  "Janeiro",
  "Fevereiro",
  "Março",
  "Abril",
  "Maio",
  "Junho",
  "Julho",
  "Agosto",
  "Setembro",
  "Outubro",
  "Novembro",
  "Dezembro",
];

var titRecipe = document.querySelectorAll(".TitRecipe");
var titPickedRecipe = document.querySelectorAll(".TitPickedRecipe");
var imgRecipe = document.querySelectorAll(".imgRecipe");
var imgPickedRecipe = document.querySelectorAll(".imgPickedRecipe");

// RENDERIZA O CALENDÁRIO
const renderCalendar = () => {
  let firstDayofMonth = new Date(currYear, currMonth, 1).getDay();
  lastDateofMonth = new Date(currYear, currMonth + 1, 0).getDate();
  lastDayofMonth = new Date(currYear, currMonth, lastDateofMonth).getDay();
  lastDateofLastMonth = new Date(currYear, currMonth, 0).getDate();
  pastDays = new Date().getDate();
  let liTag = "";
  // CÁLCULO PRA CRIAR OS DIAS DO MÊS CORRETAMENTE
  for (let i = firstDayofMonth; i > 0; i--) {
    liTag += `<li class="inactive">${lastDateofLastMonth - i + 1}</li>`;
  }

  for (let i = 1; i <= lastDateofMonth; i++) {
    if (i < pastDays) {
      if (currYear == date.getFullYear()) {
        if (currMonth == date.getMonth()) {
          liTag += `<li class="inactive">${i}</li>`;
        } else {
          liTag += `<li class="day">${i}</li>`;
        }
      } else {
        liTag += `<li class="day">${i}</li>`;
      }
    } else {
      liTag += `<li class="day">${i}</li>`;
    }
  }

  for (let i = lastDayofMonth; i < 6; i++) {
    liTag += `<li class="inactive">${i - lastDayofMonth + 1}</li>`;
  }
  // MÊS E ANO NO TOPO DO CALENDÁRIO
  currentDate.innerText = `${months[currMonth]} ${currYear}`;
  daysTag.innerHTML = liTag;

  // FUNÇÃO PRA SELECIONAR O DIA
  var pickedDay = document.querySelectorAll(".day");
  function addDayClick() {
    pickedDay.forEach((day) => {
      day.addEventListener("click", () => {
        pickedDay.forEach((d) => d.removeAttribute("class"));
        day.className = "active";
        // pRecipe é a classe de receitas já planejadas embaixo do calendário
        const pRecipe = document.querySelectorAll(".pRecipe");
        pRecipe.forEach((div, index) => {
          var finalDate = document.querySelectorAll(".date");
          finalDate.forEach((date, index) => {
            var finalDay = document.querySelector(".active");
            let slash = "/";
            finalDate[index].textContent =
              finalDay.textContent + slash + (currMonth + 1);
          });
          pRecipe[index].style.display = "flex";
        });
      });
    });
  }
  addDayClick();
};
renderCalendar();

var allDays = document.querySelector(".days");
const activateButton = document.querySelectorAll(".PlanBotao");

// CÓDIGO PRO BOTÃO DE PLANEJAR CRIAR NOVOS ELEMENTOS HTML PRA MOSTRAR AS RECEITAS PLANEJADAS ABAIXO DO CALENDÁRIO
activateButton.forEach((button, index) => {
  button.addEventListener("click", () => {
    allDays.classList.remove("disabled");
    allDays.classList.add("enabled");
    titRecipe[index] = button[index];
    imgRecipe[index] = button[index];
    const newRecipe = document.createElement("div");
    newRecipe.className = "pRecipe";
    const newDIVimgRecipe = document.createElement("div");
    newDIVimgRecipe.className = "DIVimgRecipe";
    newRecipe.appendChild(newDIVimgRecipe);
    const newIMGRecipe = document.createElement("img");
    newIMGRecipe.src = imgRecipe[index].src;
    newIMGRecipe.className = "imgPickedRecipe";
    newDIVimgRecipe.appendChild(newIMGRecipe);
    const newTitRecipe = document.createElement("p");
    newTitRecipe.innerText = titRecipe[index].innerText;
    newTitRecipe.className = "TitPickedRecipe";
    newRecipe.appendChild(newTitRecipe);
    const newDateRecipe = document.createElement("p");
    newDateRecipe.innerText = "bb/bb";
    newDateRecipe.className = "date";
    newRecipe.appendChild(newDateRecipe);
    const newXBotao = document.createElement("button");
    newXBotao.setAttribute("id", "xBotao");
    newRecipe.appendChild(newXBotao);
    const imgXBotao = document.createElement("img");
    imgXBotao.src = "../img/icons/x.png";
    newXBotao.appendChild(imgXBotao);

    const plannedRecipes = document.querySelector(".PlannedRecipes");
    const exampleDIV = document.querySelector(".example");
    plannedRecipes.insertBefore(newRecipe, exampleDIV);
  });
});

// BOTÕES DE AVANÇAR E VOLTAR MESES DO ANO DO CALENDÁRIO
prevNextIcon.forEach((icon) => {
  icon.addEventListener("click", () => {
    currMonth = icon.id === "prev" ? currMonth - 1 : currMonth + 1;
    if (icon.id === "prev") {
      if (currYear <= date.getFullYear()) {
        if (currMonth < date.getMonth()) {
          allDays.classList.remove("enabled");
          allDays.classList.add("disabled");
        }
      }
    } else {
      if (currYear >= date.getFullYear()) {
        if (currMonth >= date.getMonth()) {
          allDays.classList.remove("disabled");
          allDays.classList.add("enabled");
        }
      }
    }

    if (currMonth < 0) {
      currMonth = 11;
      currYear -= 1;
    } else if (currMonth > 11) {
      currMonth = 0;
      currYear += 1;
    }
    renderCalendar();
  });
});
