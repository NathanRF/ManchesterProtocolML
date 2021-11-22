let sortOrderDesc = true;
let Pacientes;

function hideHeaderButtons() {
    document.querySelector("#sort").setAttribute("style", "display: none");
    document.querySelector("#order-type").setAttribute("style", "display: none");
}
function showHeaderButtons() {
    document.querySelector("#sort").removeAttribute("style");
    document.querySelector("#order-type").removeAttribute("style");
}

async function updateSortOrderElement(innerHTML) {
    document.querySelector("#sort").replaceChildren(innerHTML);
}

function switchSortOrder() {
    sortOrderDesc = !sortOrderDesc;
    updateSortOrderElement(getSortOrderElement(sortOrderDesc));
    reordenarPacientes();
}

async function atualizarOrdemDaLista() {
    if (Pacientes) {
        const tipoDeOrdenacao = document.querySelector("#order-type").value;
        if (tipoDeOrdenacao === "1") {
            ordenarListaPorPrioridade(sortOrderDesc);
        }
        else if (tipoDeOrdenacao === "2") {
            ordenarListaPorNome(sortOrderDesc);
        }
        else if (tipoDeOrdenacao === "3") {
        }
    }
}

function reordenarPacientes() {
    atualizarOrdemDaLista();
    carregarListaDePacientes();
}

function getSortOrderElement(sortOrder) {
    if (sortOrder) {
        const img = document.createElement("img")
        img.src = "icons/sort-up.png"
        img.alt = "Ordem decrescente"
        img.classList.add("h-80", "w-100")
        return img;
    }
    else {
        const img = document.createElement("img")
        img.src = "icons/sort-down.png"
        img.alt = "Ordem crescente"
        img.classList.add("h-80", "w-100")
        return img;
    }
}

async function carregarPacientes() {
    Pacientes = JSON.parse(localStorage.getItem('pacientes'));
}

async function carregarListaDePacientes() {
    if (Pacientes) {
        document.querySelector('#emptyList').setAttribute("style", "display: none");
        document.querySelector("#pacientes").replaceChildren();
        Pacientes.forEach(paciente => {
            const pacienteElement = document.createElement("li");
            pacienteElement.classList.add("py-2", "px-2", "border-bottom", "patient-card");
            pacienteElement.innerHTML = `
                <a href="./paciente?id=${paciente.id}">
                    <div class="d-grid">
                        <div>
                            <h2>${paciente.nome + ' ' + paciente.sobrenome} </h2>
                            <div class="detalhes d-flex flex-sb">
                                <p class="py-3 px-2">${paciente.sintomasLabels?.join(', ')}</p>
                                <p>Editar 📝</p>
                            </div>
                            <div class="listaStatus d-flex">
                                <span class="prioridade rounded-pill ${replaceWhiteSpace(normalize(paciente.prioridadeLabel))}">${paciente.prioridadeLabel}</span>
                                <span class="status ${replaceWhiteSpace(normalize(paciente.statusLabel))} rounded-pill">${paciente.statusLabel}</span>
                            </div>
                        </div>
                    </div>
                </a>
                `;
            document.querySelector("#pacientes").appendChild(pacienteElement);
        });
    }
    else {
        document.querySelector('#emptyList').setAttribute("style", "display: show");
    }

}

function search() {
    const searchTerm = normalize(document.querySelector("#list-search").value);
    document.querySelectorAll(".patient-card").forEach(paciente => {
        if (normalize(paciente.querySelector("h2").innerText)?.includes(searchTerm)
            ||
            normalize(paciente.querySelector("div span").innerText)?.includes(searchTerm)) {

            paciente.style.display = "block";
        }
        else {
            paciente.style.display = "none";
        }
    });
}

function normalize(text) {
    return text ? text.toLowerCase().normalize("NFD").replace(/\p{Diacritic}/gu, "") : '';
}

function replaceWhiteSpace(text) {
    return text.replace(' ', '-');
}

async function inicializar() {
    await updateSortOrderElement(getSortOrderElement(sortOrderDesc));
    await carregarPacientes();
    await atualizarOrdemDaLista();
    await carregarListaDePacientes();
}

function ordenarListaPorNome(desc) {
    Pacientes.sort((a, b) => {
        if (desc) {
            return a.nome.toLowerCase().localeCompare(b.nome.toLowerCase());
        }
        else {
            return b.nome.toLowerCase().localeCompare(a.nome.toLowerCase());
        }
    });
}

function ordenarListaPorPrioridade(desc) {
    Pacientes.sort((a, b) => {
        if (!desc) {
            return a.situacao?.codigoPrioridade?.toString()?.localeCompare(b.situacao?.codigoPrioridade?.toString());
        }
        else {
            return b.situacao?.codigoPrioridade?.toString()?.localeCompare(a.situacao?.codigoPrioridade?.toString());
        }
    });
}

window.addEventListener("load", inicializar);
document.getElementById("add").addEventListener("click", () => {
    document.location.href = "paciente";
});

document.querySelector("#sort").addEventListener("click", switchSortOrder);
document.querySelector("#order-type").onchange = reordenarPacientes;
document.querySelector("#list-search").addEventListener("focus", hideHeaderButtons);
document.querySelector("#list-search").addEventListener("blur", showHeaderButtons);
document.querySelector("#list-search").addEventListener("input", search);

//navigator.serviceWorker.register('/sw.js');