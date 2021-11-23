"use strict";
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
        document.querySelector('#id').value = paciente.id;
        document.querySelector('#nome').value = paciente.nome;
        document.querySelector('#sobrenome').value = paciente.sobrenome;
        document.querySelector('#idade').value = paciente.idade;
        document.querySelector('#chegada').value = new Date(paciente.horaDeEntrada).toISOString().split('T')[1].substring(0, 5);
        let sintomasSelecionados = new Array();
        const sintomasDisponiveis = Array.prototype.slice.call(document.querySelector('#sintoma').options);

        for (var i = 0; i < paciente.sintomas.length; i++) {
            document.getElementById('sintoma').options[sintomasDisponiveis.filter(s => s.value == paciente.sintomas[i])[0].index].selected = true;
        }

        $(document).ready(function () {
            $('#sintoma').select2({
                width: 'auto',
                id: 'sintoma'
            });
        });

        document.querySelector('#coracao').value = paciente.frequenciaCardiaca;
        document.querySelector('#temperatura').value = paciente.temperatura;
        document.querySelector('#oxigenio').value = paciente.saturacaoOxigenio;
        document.querySelector('#respiracao').value = paciente.frequenciaRespiratoria;
        document.querySelector('#status').value = paciente.status;
        document.querySelector('#priority').value = paciente.prioridade;
    }
}

function horaDeChegadaPadrao() {
    const today = new Date();
    const now = today.toLocaleTimeString().substring(0, 5);
    document.querySelector('#chegada').value = now;
}

function formularioDeCriacao() {
    horaDeChegadaPadrao();
}

function bloquearCamposEdicao() {
    document.querySelector('#nome').disabled = true;
    document.querySelector('#sobrenome').disabled = true;
    document.querySelector('#idade').disabled = true;
    document.querySelector('#chegada').disabled = true;
    document.querySelector('#priority').disabled = true;
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
    exibirCamposOcultos();
    bloquearCamposEdicao();
    preencheFormulario(paciente);
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
    if (element.value && document.querySelector(`label[for="${elementId}"]`)) {
        document.querySelector(`label[for="${elementId}"]`).style.visibility = 'visible';
    }
    else if (document.querySelector(`label[for="${elementId}"]`)) {
        document.querySelector(`label[for="${elementId}"]`).style.visibility = 'hidden';
    }
}

function prepararSalvamentoPaciente() {
    if (editando) {
        let pacienteEdit = pacientes.filter(p => p.id == getId())[0] ?? new Object();
        //pacienteEdit.sintoma = Sintomas.filter(sintoma => sintoma.nome == document.querySelector('#sintoma').value)[0]
        pacienteEdit.frequenciaCardiaca = document.querySelector('#coracao').value;
        pacienteEdit.temperatura = document.querySelector('#temperatura').value;
        pacienteEdit.saturacaoOxigenio = document.querySelector('#oxigenio').value;
        pacienteEdit.frequenciaRespiratoria = document.querySelector('#respiracao').value;
        pacienteEdit.status = document.querySelector('#status').value;
        pacienteEdit.statusLabel = document.querySelector('#status').selectedOptions[0].label;
        pacienteEdit.prioridade = document.querySelector('#priority').value;
        pacienteEdit.prioridadeLabel = document.querySelector('#priority').selectedOptions[0].label;

        pacienteEdit.sintomas = new Array();
        pacienteEdit.sintomasLabels = new Array();
        const options = document.querySelector('#sintoma').selectedOptions;
        for (var i = 0; i < options.length; i++) {
            pacienteEdit.sintomas.push(options[i].value);
            pacienteEdit.sintomasLabels.push(options[i].label);
        }

        pacientes.filter(p => p.id == getId())[0] = pacienteEdit;
        console.log("edit form");
    }
    else {
        let paciente = new Object();
        paciente.id = uuidv4();
        document.querySelector('#id').value = paciente.id;
        paciente.nome = document.querySelector('#nome').value;
        paciente.sobrenome = document.querySelector('#sobrenome').value;
        paciente.idade = document.querySelector('#idade').value;
        paciente.horaDeEntrada = new Date((new Date()).toISOString().split('T')[0]+'T'+document.querySelector('#chegada').value);
        //paciente.prontuario = new Prontuario();
        //paciente.sintoma = Sintomas.filter(sintoma => sintoma.nome == document.querySelector('#sintoma').value)[0];
        paciente.sintomas = new Array();
        paciente.sintomasLabels = new Array();
        const options = document.querySelector('#sintoma').selectedOptions;
        for (var i = 0; i < options.length; i++) {
            paciente.sintomas.push(options[i].value);
            paciente.sintomasLabels.push(options[i].label);
        }
        paciente.frequenciaCardiaca = document.querySelector('#coracao').value;
        paciente.temperatura = document.querySelector('#temperatura').value;
        paciente.saturacaoOxigenio = document.querySelector('#oxigenio').value;
        paciente.frequenciaRespiratoria = document.querySelector('#respiracao').value;
        //paciente.situacao = new Situacao();
        paciente.status = document.querySelector('#status').value;
        paciente.statusLabel = document.querySelector('#status')[document.querySelector('#status').selectedIndex].text;
        paciente.prioridade = document.querySelector('#priority').value;
        paciente.prioridadeLabel = document.querySelector('#priority')[document.querySelector('#priority').selectedIndex].text;

        pacientes.push(paciente);
        console.log("create form");
    }

    localStorage.setItem('pacientes', JSON.stringify(pacientes));
}

window.addEventListener("load", carregarLista);

document.getElementById("cancel").addEventListener("click", () => {
    document.location.href = "home";
});

document.getElementById("save").addEventListener("click", () => {
    prepararSalvamentoPaciente();
    //document.location.href = "home";
    document.getElementById("paciente").submit();
});

document.querySelectorAll(".detail").forEach(element => {
    element.addEventListener("input", () => {
        toggleFieldsInnerLabel(element);
    });
});