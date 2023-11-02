let campoVitoria = document.getElementById("vitorias");
let campoDerrota = document.getElementById("derrotas");
let campoTotalLutas = document.getElementById("totalLutas");

function somaTotalLutas() {
    campoTotalLutas.value = parseInt(campoVitoria.value) + parseInt(campoDerrota.value);
}

somaTotalLutas();