// Stop "Enter"
document.addEventListener("keydown", function (event) {
    if (event.key === "Enter") {
        event.preventDefault();
    }
});



// Fix categories

let categorias = Array.from(document.getElementsByClassName("categorias"))

categorias.forEach((categorias) => {
    categorias.innerHTML = categorias.innerHTML.replaceAll("_", " ");
})

// Img
const receitaImage = document.querySelector('#receita-image');
const containerImage = document.querySelector('#div-image');
const previewNull = document.querySelector('#preview-null')

receitaImage.addEventListener('change', event => {
    const preview = document.querySelector('#preview-image');

    if (preview) {
        preview.remove()
    }

    const reader = new FileReader;
    console.log(receitaImage.files[0]);
    var files = event.target.files;
    var extension = files[0].type;

    if (extension == "image/jpeg" || extension == "image/png" || extension == "image/jpg") {


        reader.onload = function (event) {
            const previewImage = document.createElement('img');
            previewImage.width = 200;
            previewImage.height = 200;
            previewImage.classList.add("img-thumbnail");
            previewImage.id = 'preview-image';
            previewImage.src = event.target.result;
            previewNull.remove();
            containerImage.appendChild(previewImage);
        }

        reader.readAsDataURL(receitaImage.files[0])
    } else {
        containerImage.appendChild(previewNull)
    }
})

// Yield Increase/decrease
const rendimentInput = document.getElementById('Rendimento');
const incrementButton = document.getElementById('button-increment');
const decrementButton = document.getElementById('button-decrement');
incrementButton.addEventListener('click', function () {
    const value = parseInt(rendimentInput.value) || 0;
    if (value < 99) {
        rendimentInput.value = value + 1;
    }
});
decrementButton.addEventListener('click', function () {
    const value = parseInt(rendimentInput.value) || 0;
    if (value > 0) {
        rendimentInput.value = value - 1;
    }
});

// Steps
const Passos = document.getElementById('containerPassos');
const BtnCreateInput = document.getElementById('button-create-input');
const BtnDeleteInput = document.getElementById('button-delete-input');
let PassosIndex = document.querySelectorAll(".prevSteps").length;

// Add step
BtnCreateInput.addEventListener('click', function () {
    PassosIndex++;
    let NewPasso = document.createElement("div");
    NewPasso.classList.add("form-floating", "w-100");

    NewPasso.innerHTML = `<input type="text" name="Passos" placeholder="Passo ${PassosIndex}" class="form-control" />
                                  <label class="control-label fw-normal p-3">Passo ${PassosIndex}</label>`;

    Passos.appendChild(NewPasso);
});

// Remove last step
BtnDeleteInput.addEventListener('click', function () {
    if (PassosIndex > 1) {
        Passos.removeChild(Passos.lastElementChild);
        PassosIndex--;
    }
});

// Ingredients

//props
let ingredientsDiv = document.getElementById("IngredientList");
let selectedIngDiv = document.getElementById("container-ingSelected");
let ingredients = Array.from(document.querySelectorAll(".ingredient"));
// let selectedIng = Array.from(document.querySelectorAll(".selectedIng")); --> Ja declarada no .cshtml
let ingIndex = selectedIng.length

// Evento delegado para adicionar ingredientes
ingredientsDiv.addEventListener("click", function (event) {
    let ing = event.target.closest(".ingredient");
    if (ing) {
        addToRecipe(ing);
    }
});

// Evento delegado para remover ingredientes
selectedIngDiv.addEventListener("click", function (event) {
    let btn = event.target.closest(".btnIng");
    if (btn) {
        let slctdIng = btn.closest(".selectedIng");
        if (slctdIng) {
            removeFromRecipe(slctdIng);
        }
    }
});

document.getElementById('search-string').addEventListener('input', function () {
    const searchString = document.getElementById('search-string').value;

    fetch(`/Receitas/Search?searchString=${encodeURIComponent(searchString)}`)
        .then(response => response.text())
        .then(data => {
            document.getElementById('IngredientList').innerHTML = data;
            
        })
        .catch(error => console.error('Erro ao buscar ingredientes:', error));
});

$(document).ready(function () {
    $('#submit-button').click(function (e) {
        e.preventDefault();

        let formData = $('#create-ingredient-form').serialize();

        $.ajax({
            url: '/Home/Create',
            type: 'POST',
            data: formData,
            success: function (response) {
                alert('Ingrediente criado com sucesso!');
                $('#modal').modal('hide');
            },
            error: function (xhr, status, error) {
                alert('Erro ao criar o ingrediente: ' + xhr.responseText);
            }
        });
    });
});

function addToRecipe(ing) {
    //props
    let id = ing.getAttribute("idingrediente")
    let nome = ing.querySelector("div").innerText;

    //add
    let struct = document.createElement("div");
    struct.setAttribute("idingrediente", id);
    struct.setAttribute("dataindex", ingIndex);

    struct.classList.add("card", "d-flex", "flex-row", "justify-content-between", "align-items-center", "p-3", "gap-2", "selectedIng")

    struct.innerHTML = `
                <label class="fw-bold w-50">${nome}</label>
                <input class="form-control w-25" type="number" placeholder="Quantidade" name="IngredientesSelecionados[${ingIndex}].Quantidade" value="" min="1" required/>
                <select class="form-control w-25" name="IngredientesSelecionados[${ingIndex}].Tipo">
                    <option value="0" selected>Litros</option>
                    <option value="1">Mililitros</option>
                    <option value="2">Quilos</option>
                    <option value="3">Gramas</option>
                    <option value="4">Xícaras</option>
                    <option value="5">Colheres_de_Sopa</option>
                    <option value="6">Colheres_de_Chá</option>
                    <option value="7">Colheres_de_Café</option>
                    <option value="8">Copos</option>
                    <option value="9">Unidades</option>
                </select>
                <input type="hidden" name="IngredientesSelecionados[${ingIndex}].IdIngrediente" value="${id}" />
            `;

    selectedIngDiv.appendChild(struct)

    //rem
    ing.remove();

    //update
    ingIndex++;
    updateDel();
}

function removeFromRecipe(ing) {
    //props
    let id = ing.getAttribute("idingrediente")
    let nome = ing.querySelector("label").innerText

    //add
    let struct = document.createElement("div");
    struct.setAttribute("idingrediente", id);

    struct.classList.add("ingredient", "btn", "btn-outline-secondary", "d-flex", "flex-row", "justify-content-center", "align-content-between", "p-2")
    struct.innerHTML = `
                <div>${nome}</div>
                `;

    ingredientsDiv.appendChild(struct);

    //rem
    ing.remove();

    //update
    ingIndex--;
    updateDel();
}
let ingList = []
function updateDel() {
    ingList = Array.from(document.querySelectorAll(".selectedIng"))
    ingList.forEach(ing => {
        if (parseInt(ing.getAttribute("dataindex")) == ingIndex - 1) {

            let button = document.createElement("button");
            button.classList.add("btnIng", "btn", "btn-danger", "d-flex", "justify-content-center", "align-items-center");
            button.type = "button";

            let img = document.createElement("img");
            img.classList.add("icon-regular");
            img.style.filter = "invert()";
            img.src = "/img/icons/remove.png";

            button.appendChild(img);
            ing.appendChild(button);
        } else {
            if (ing.querySelector("button")) {
                ing.querySelector("button").remove();
            }

        }
    })
}
updateDel()
