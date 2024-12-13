function loadStylesheet(path) {
  let stylesheetLink = document.createElement("link");
  stylesheetLink.rel = "stylesheet";
  stylesheetLink.href = path;
  document.head.appendChild(stylesheetLink);
}

function drawHeader(isPage) {
  let header = document.querySelector("header");
  let logoPath = isPage ? "../index.html" : "index.html";
  let imgPath = isPage
    ? "../img/extendedLogoWhite.png"
    : "img/extendedLogoWhite.png";
  let authPath = isPage ? "auth.html" : "../src/pages/auth.html";

  let Struct = `
    <div id="containerHeader">
      <button id="logoHeader" onclick="window.location.href='${logoPath}'">
        <img src="${imgPath}" alt="Logo" id="imgLogo">
      </button>
      <input type="text" id="searchInput" placeholder="Busque por receitas!">
      <img src="${
        isPage
          ? "../img/icons/search.png"
          : "img/icons/search.png"
      }" alt="Search" id="searchIcon">
      <div id="pagesBtns">
        <button id="btnPage" onclick="window.location.href='${authPath}'">Entrar</button>
      </div>
    </div>
  `;

  header.innerHTML = Struct;
  loadStylesheet(
    isPage ? "../css/modules/render.css" : "css/modules/render.css"
  );
}

function drawFooter() {
  let footer = document.querySelector("footer");
  let Struct = `
    <p id="copyrightTerms">© 2024 PratoDoDia. Todos os direitos reservados.</p>
  `;
  footer.innerHTML = Struct;
}

(function init() {
  let path = window.location.pathname;
  let isPage = path.includes("pages");

  drawHeader(isPage);
  drawFooter();
})();
