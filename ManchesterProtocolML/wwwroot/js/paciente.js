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
        //document.querySelector('#chegada').value = new Date(paciente.horaDeEntrada).toISOString().split('T')[1].substring(0, 5);
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

function obterErrosFormulario() {
    const validationElements = document.querySelectorAll(".validation");
    let validations = new Array();
    validationElements.forEach(element => {
        if(element.textContent)
            validations.push(element.textContent);
    });
    return validations;
}

function formularioSemErros() {
    return obterErrosFormulario().length === 0;
}

function alertaErrosFormulario() {
    alert(obterErrosFormulario().join('\n'));
}

async function prepararSalvamentoPaciente() {
    if (formularioSemErros()) {
        if (editando) {
            let pacienteEdit = pacientes.filter(p => p.id == getId())[0] ?? new Object();
            pacienteEdit.frequenciaCardiaca = document.querySelector('#coracao').value;
            pacienteEdit.temperatura = document.querySelector('#temperatura').value;
            pacienteEdit.saturacaoOxigenio = document.querySelector('#oxigenio').value;
            pacienteEdit.frequenciaRespiratoria = document.querySelector('#respiracao').value;
            pacienteEdit.status = document.querySelector('#status').value;
            pacienteEdit.statusLabel = document.querySelector('#status').selectedOptions[0].label;

            pacienteEdit.sintomas = new Array();
            pacienteEdit.sintomasLabels = new Array();
            const options = document.querySelector('#sintoma').selectedOptions;
            for (var i = 0; i < options.length; i++) {
                pacienteEdit.sintomas.push(options[i].value);
                pacienteEdit.sintomasLabels.push(options[i].label);
            }

            const priorityCode = await obterPrioridade();

            const priorities = Array.prototype.slice.call(document.querySelector('#priority').options);
            const priority = document.getElementById('priority').options[priorities.filter(s => s.value == priorityCode)[0].index];

            pacienteEdit.prioridade = priority.value;
            pacienteEdit.prioridadeLabel = priority.text;


            pacientes.filter(p => p.id == getId())[0] = pacienteEdit;
        }
        else {
            let paciente = new Object();
            paciente.id = uuidv4();
            document.querySelector('#id').value = paciente.id;
            paciente.nome = document.querySelector('#nome').value;
            paciente.sobrenome = document.querySelector('#sobrenome').value;
            paciente.idade = document.querySelector('#idade').value;
            paciente.horaDeEntrada = new Date((new Date()).toISOString().split('T')[0] + 'T' + document.querySelector('#chegada').value);
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
            paciente.status = document.querySelector('#status').value;
            paciente.statusLabel = document.querySelector('#status')[document.querySelector('#status').selectedIndex].text;

            const priorityCode = await obterPrioridade();

            const priorities = Array.prototype.slice.call(document.querySelector('#priority').options);
            const priority = document.getElementById('priority').options[priorities.filter(s => s.value == priorityCode)[0].index];

            paciente.prioridade = priority.value;
            paciente.prioridadeLabel = priority.text;

            pacientes.push(paciente);
        }

        localStorage.setItem('pacientes', JSON.stringify(pacientes));
    }
    else {
        alertaErrosFormulario();
    }
}

async function obterPrioridade() {
    var url = $("#paciente").attr("action");
    var formData = new FormData();

    formData.append("age", $("#idade").val() ?? 0);
    formData.append("heartRate", $("#coracao").val() ?? 0);
    formData.append("oxygenSaturation", $("#oxigenio").val() ?? 0);
    formData.append("temperature", $("#temperatura").val() ?? 0);
    formData.append("respiratoryRate", $("#respiracao").val() ?? 0);
    formData.append("positiveDiscriminator", document.querySelector('#sintoma').selectedOptions[0].value ?? 0);
    formData.append("presentingProblem", document.querySelector('#sintoma').selectedOptions[0].getAttribute('tipo') ?? 0);

    let priority;
    await $.ajax({
        type: 'POST',
        url: url,
        data: formData,
        processData: false,
        contentType: false
    }).done(function (response) {
        if (response === 0 || response) {
            priority = response;
        }
        else {
            throw new Error('Request error');
        }
    });
    return priority;
}

window.addEventListener("load", carregarLista);

document.getElementById("cancel").addEventListener("click", () => {
    document.location.href = "home";
});

document.getElementById("save").addEventListener("click", async () => {
    await prepararSalvamentoPaciente();
    document.location.href = "home";
    //document.getElementById("paciente").submit();
});

document.querySelectorAll(".detail").forEach(element => {
    element.addEventListener("input", () => {
        toggleFieldsInnerLabel(element);
    });
});