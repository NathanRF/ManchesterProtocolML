let pacientes = localStorage.getItem('pacientes') ? JSON.parse(localStorage.getItem('pacientes')) : [];
let editando = true;

function uuidv4() {
    return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}

function buscaPacientePorId(id) {
    if (id) {
        return pacientes.filter(paciente => paciente.id == id)[0];
    }
}

function preencheFormulario(paciente) {
    if (paciente) {
        document.querySelector('#nome').value = paciente.nome;
        document.querySelector('#sobrenome').value = paciente.sobrenome;
        document.querySelector('#idade').value = paciente.idade;
        document.querySelector('#chegada').value = paciente.horaDeEntrada;
        document.querySelector('#sintoma').value = paciente.sintoma.nome;
        document.querySelector('#coracao').value = paciente.frequenciaCardiaca;
        document.querySelector('#temperatura').value = paciente.temperatura;
        document.querySelector('#oxigenio').value = paciente.saturacaoOxigenio;
        document.querySelector('#respiracao').value = paciente.frequenciaRespiratoria;
        document.querySelector('#status').options[obterCodigoStatus(paciente.status)].selected = true;
        document.querySelector('#priority').options[obterCodigoPrioridade(paciente.prioridade) - 1].selected = true;
    }
}

function horaDeChegadaPadrao() {
    const today = new Date();
    const now = today.toLocaleTimeString().substring(0, 5);
    document.querySelector('#chegada').value = now;
}

function formularioDeCriacao() {
    popularSintomas();
    horaDeChegadaPadrao();
}

function bloquearCamposEdicao() {
    document.querySelector('#nome').disabled = true;
    document.querySelector('#sobrenome').disabled = true;
    document.querySelector('#idade').disabled = true;
    document.querySelector('#chegada').disabled = true;
}

function atualizatitulo(titulo) {
    document.querySelector('.page-title').innerText = titulo;
}

function exibirCamposOcultos() {
    document.querySelector('#status').style.display = 'block';
    document.querySelector('#statusLabel').style.display = 'block';
}

function formularioDeEdicao(paciente) {
    atualizatitulo("Editar paciente");
    //popularSintomas();
    exibirCamposOcultos();
    bloquearCamposEdicao();
    //preencheFormulario(paciente);
}

function getId() {
    const params = (new URL(document.location)).searchParams;
    return params.get("id");
}

function carregarLista() {
    const id = getId();

    if (id) {
        const paciente = buscaPacientePorId(id);
        if (paciente) {
            formularioDeEdicao(paciente);
        }
    }
    else {
        editando = false;
        formularioDeCriacao();
    }
    document.querySelectorAll(".detail").forEach(element => {
        toggleFieldsInnerLabel(element);
    });
}

function toggleFieldsInnerLabel(element) {
    const elementId = element.id;
    if (element.value) {
        document.querySelector(`label[for="${elementId}"]`).style.visibility = 'visible';
    }
    else {
        document.querySelector(`label[for="${elementId}"]`).style.visibility = 'hidden';
    }
}

function salvarPaciente() {
    debugger;
    if (editando) {
        let pacienteEdit = pacientes.filter(p => p.id == getId())[0] ?? new Object();
        //pacienteEdit.sintoma = Sintomas.filter(sintoma => sintoma.nome == document.querySelector('#sintoma').value)[0]
        pacienteEdit.frequenciaCardiaca = document.querySelector('#coracao').value;
        pacienteEdit.temperatura = document.querySelector('#temperatura').value;
        pacienteEdit.saturacaoOxigenio = document.querySelector('#oxigenio').value;
        pacienteEdit.frequenciaRespiratoria = document.querySelector('#respiracao').value;
        pacienteEdit.status = document.querySelector('#status').value;
        pacienteEdit.prioridade = document.querySelector('#priority').value;

        pacientes.filter(p => p.id == getId())[0] = pacienteEdit;
    }
    else {
        const paciente = new Paciente();
        paciente.id = uuidv4();
        paciente.nome = document.querySelector('#nome').value;
        paciente.sobrenome = document.querySelector('#sobrenome').value;
        paciente.idade = document.querySelector('#idade').value;
        paciente.horaDeEntrada = document.querySelector('#chegada').value;
        //paciente.prontuario = new Prontuario();
        //paciente.sintoma = Sintomas.filter(sintoma => sintoma.nome == document.querySelector('#sintoma').value)[0];
        paciente.frequenciaCardiaca = document.querySelector('#coracao').value;
        paciente.temperatura = document.querySelector('#temperatura').value;
        paciente.saturacaoOxigenio = document.querySelector('#oxigenio').value;
        paciente.frequenciaRespiratoria = document.querySelector('#respiracao').value;
        //paciente.situacao = new Situacao();
        paciente.status = document.querySelector('#status').value;
        paciente.prioridade = document.querySelector('#priority').value;

        pacientes.push(paciente);
    }

    localStorage.setItem('pacientes', JSON.stringify(pacientes));
}

window.addEventListener("load", carregarLista);

document.getElementById("cancel").addEventListener("click", () => {
    document.location.href = "home";
});

document.getElementById("save").addEventListener("click", () => {
    salvarPaciente();
    document.location.href = "home";
});

document.querySelectorAll(".detail").forEach(element => {
    element.addEventListener("input", () => {
        toggleFieldsInnerLabel(element);
    });
});