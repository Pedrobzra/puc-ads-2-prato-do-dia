// Stop "Enter"
document.addEventListener("keydown", function (event) {
    if (event.key === "Enter") {
        event.preventDefault();
    }
});

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
            previewImage.width = 300;
            previewImage.height = 300;
            previewImage.classList.add("img-thumbnail");
            previewImage.id = 'preview-image';
            previewImage.src = event.target.result;
            previewNull.remove();
            containerImage.appendChild(previewImage);
        }

        reader.readAsDataURL(receitaImage.files[0])
    }

    else {
        containerImage.appendChild(previewNull)
    }

})

let categorias = Array.from(document.getElementsByClassName("categorias"))

categorias.forEach((categorias) => {
    categorias.innerHTML = categorias.innerHTML.replaceAll("_", " ");
})

const Passos = document.getElementById('containerPassos');
const BtnCreateInput = document.getElementById('button-create-input');
const BtnDeleteInput = document.getElementById('button-delete-input');
var PassosIndex = 1;

BtnCreateInput.addEventListener('click', function () {
    PassosIndex++;
    let NewPasso = document.createElement("div");
    NewPasso.classList.add("form-floating", "w-100");

    NewPasso.innerHTML = `<input type="text" name="Passos" asp-for="Passos" placeholder="Passo ${PassosIndex}" class="form-control" />
                        <label class="control-label fw-normal p-3">Passo ${PassosIndex}</label>`;

    Passos.appendChild(NewPasso);
});

BtnDeleteInput.addEventListener('click', function () {
    if (PassosIndex > 1) {
        containerPassos.removeChild(containerPassos.lastChild);
        PassosIndex--;
    };
});

// Função de incremento em rendimento
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
document.getElementById('search-string').addEventListener('input', function () {
    const searchString = document.getElementById('search-string').value;

    fetch(`/Receitas/Search?searchString=${encodeURIComponent(searchString)}`)
        .then(response => response.text())
        .then(data => {
            document.getElementById('IngredientList').innerHTML = data;
            attachIngredientClickEvents();
        })
        .catch(error => console.error('Erro ao buscar ingredientes:', error));
});

const containerIng = document.getElementById('container-ingSelected');
var ingIndex = 0;

function attachIngredientClickEvents() {
    const ingredients = document.querySelectorAll(".ingredient");
    ingredients.forEach((ingredient) => {
        ingredient.onclick = () => {
            let ingName = ingredient.innerHTML;
            let ingId = ingredient.getAttribute("IdIngrediente");
            let ingStruct = document.createElement("div");
            ingStruct.classList.add("card", "d-flex", "flex-row", "justify-content-between", "align-items-center", "p-3", "gap-2");

            ingStruct.innerHTML = `
                <label class="fw-bold w-50">${ingName}</label>
                <input class="form-control w-25" type="number" asp-for="Quantidade" placeholder="Quantidade" name="IngredientesSelecionados[${ingIndex}].Quantidade" value="" min="0"/>
                <select class="form-control" asp-for="TipoQuantidade" w-25" name="IngredientesSelecionados[${ingIndex}].Tipo">
                    <option selected value="0">Litros</option>
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
                <input type="hidden" name="IngredientesSelecionados[${ingIndex}].IdIngrediente" value="${ingId}" />
                 <button class="btnIng btn btn-danger d-flex justify-content-center align-items-center" type="button">
                            <img class= "icon-regular" style="filter: invert();" src="/img/icons/remove.png" alt=""/>
                 </button>
            `;

            containerIng.appendChild(ingStruct);
            ingredient.remove();
            ingIndex++;

            const removeButton = ingStruct.querySelector(".btnIng");
            removeButton.onclick = () => {
                document.getElementById('IngredientList').appendChild(ingredient);
                ingStruct.remove();
            }
        }
    });
}

//AJAX INGREDIENTE CREATE

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

attachIngredientClickEvents();

