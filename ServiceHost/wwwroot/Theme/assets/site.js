function updatePrice(id, unitPrice, usdRate, aedRate) {
    const countInput = document.getElementById(`count-${id}`);
    const count = parseInt(countInput.value);
    const max = parseInt(countInput.dataset.defaultcount);
    const errorMsg = document.getElementById(`errorMsg-${id}`);

    let validCount = count;

    if (count > max) {
        errorMsg.style.display = "block";
        validCount = max;
        countInput.value = max;
    } else {
        errorMsg.style.display = "none";
    }

    const finalRial = validCount * unitPrice;
    const finalUsd = validCount * usdRate;
    const finalAed = validCount * aedRate;

    document.getElementById(`finalPrice-${id}`).innerText = finalRial.toLocaleString();
    document.getElementById(`finalPriceUsd-${id}`).innerText = finalUsd.toFixed(2);
    document.getElementById(`finalPriceAed-${id}`).innerText = finalAed.toFixed(2);
}