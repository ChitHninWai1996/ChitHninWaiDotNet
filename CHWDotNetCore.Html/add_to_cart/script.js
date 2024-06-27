let cart = [];
let totalAmount = 0;

function addToCart(productName, price) {
    const existingProduct = cart.find(item => item.name === productName);

    if (existingProduct) {
        existingProduct.quantity += 1;
    } else {
        cart.push({ name: productName, price: price, quantity: 1 });
    }

    updateCart();
    updateTotalAmount();
}

function updateCart() {
    const cartTableBody = document.querySelector('#cartTable tbody');
    cartTableBody.innerHTML = '';

    cart.forEach(item => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${item.name}</td>
            <td>${item.quantity}</td>
            <td>$${item.price * item.quantity}</td>
        `;
        cartTableBody.appendChild(row);
    });
}

function updateTotalAmount() {
    totalAmount = cart.reduce((sum, item) => sum + (item.price * item.quantity), 0);
    document.getElementById('totalAmount').textContent = totalAmount.toFixed(2);
}
