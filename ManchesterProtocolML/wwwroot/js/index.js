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

//async function carregarPacientesDeTeste() {
//    if (!localStorage.getItem('pacientes')) {
//        const today = new Date();
//        const now = today.toLocaleTimeString().substring(0, 5);
//        localStorage.setItem('pacientes', JSON.stringify([
//            new Paciente(1, 'Tom', 'Hagen', 89, now, new Prontuario(100, 36, 99, 20, 0, Sintomas.filter(s => s.id == 125)[0]), new Situacao('Em consulta', 'Emergência', obterCodigoPrioridade('Emergência'))),
//            new Paciente(2, 'Peter', 'Clemenza', 88, now, new Prontuario(124, 36.5, 100, 18, 0, Sintomas.filter(s => s.id == 43)[0]), new Situacao('Em consulta', 'Muito Urgente', obterCodigoPrioridade('Muito Urgente'))),
//            new Paciente(3, 'Henry', 'Hill', 78, now, new Prontuario(70, 36.6, 100, 17, 0, Sintomas.filter(s => s.id == 43)[0]), new Situacao('Em espera', 'Urgente', obterCodigoPrioridade('Urgente'))),
//            new Paciente(4, 'Jimmy', 'Conway', 78, now, new Prontuario(78, 36, 99, 18, 0, Sintomas.filter(s => s.id == 43)[0]), new Situacao('Em espera', 'Pouco Urgente', obterCodigoPrioridade('Pouco Urgente'))),
//            new Paciente(5, 'Tommy', 'DeVito', 93, now, new Prontuario(60, 36.2, 100, 20, 0, Sintomas.filter(s => s.id == 43)[0]), new Situacao('Atendido', 'Não Urgente', obterCodigoPrioridade('Não Urgente'))),
//        ]));
//    }
//}

async function carregarPacientes() {
    Pacientes = JSON.parse(localStorage.getItem('pacientes'));
}

async function carregarListaDePacientes() {
    try {
        document.querySelector("#pacientes").replaceChildren();
        Pacientes.forEach(paciente => {
            const pacienteElement = document.createElement("li");
            pacienteElement.classList.add("py-2", "px-2", "border-bottom", "patient-card");
            // pacienteElement.id = paciente.id;
            pacienteElement.innerHTML = `
            <a href="./pacienteDetalhes.html?id=${paciente.id}">
                <div class="d-grid">
                    <div>
                        <h2>${paciente.nome + ' ' + paciente.sobrenome} </h2>
                        <div class="detalhes d-flex flex-sb">
                            <p class="py-3 px-2">${Sintomas.filter(sintoma => sintoma.id == paciente.prontuario.sintoma.id)[0]?.nome}</p>
                            <p>Editar 📝</p>
                        </div>
                        <div class="listaStatus d-flex">
                            <span class="prioridade ${paciente.situacao.prioridade.toLowerCase().split(' ').join('-').normalize("NFD").replace(/\p{Diacritic}/gu, "")} rounded-pill">${paciente.situacao.prioridade}</span>
                            <span class="status ${paciente.situacao.status.toLowerCase().includes('esperando') ? 'aguardando' : paciente.situacao.status.toLowerCase().split(' ').join('-').normalize("NFD").replace(/\p{Diacritic}/gu, "")} rounded-pill">${paciente.situacao.status}</span>
                        </div>
                    </div>
                </div>
            </a>
            `;
            document.querySelector("#pacientes").appendChild(pacienteElement);
        });
    }
    catch (e) {
        console.log(e);
        localStorage.clear();
    }
}

function search() {
    const searchTerm = document.querySelector("#list-search").value.toLowerCase().normalize("NFD").replace(/\p{Diacritic}/gu, "");
    document.querySelectorAll(".patient-card").forEach(paciente => {
        if (paciente.querySelector("h2").innerText
            .toLowerCase().normalize("NFD")
            .replace(/\p{Diacritic}/gu, "").includes(searchTerm)
            ||
            paciente.querySelector("div span").innerText
                .toLowerCase().normalize("NFD")
                .replace(/\p{Diacritic}/gu, "").includes(searchTerm)) {

            paciente.style.display = "block";
        }
        else {
            paciente.style.display = "none";
        }
    });
}

async function inicializar() {
    await updateSortOrderElement(getSortOrderElement(sortOrderDesc));
    await carregarPacientesDeTeste();
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
    document.location.href = "pacienteDetalhes.html";
});

document.querySelector("#sort").addEventListener("click", switchSortOrder);
document.querySelector("#order-type").onchange = reordenarPacientes;
document.querySelector("#list-search").addEventListener("focus", hideHeaderButtons);
document.querySelector("#list-search").addEventListener("blur", showHeaderButtons);
document.querySelector("#list-search").addEventListener("input", search);

navigator.serviceWorker.register('/sw.js');