paypal.Buttons({
	// 3. Configurer la transaction
	createOrder: function (data, actions) {

		// Les produits à payer avec leurs details
		var produits = [
			{
				name: "House",
				description: "description",
				quantity: 1,
				unit_amount: { value: 2000, currency_code: "USD" }
			}
		];

		// Le total des produits
		var total_amount = produits.reduce(function (total, product) {
			return total + product.unit_amount.value * product.quantity;
		}, 0);

		// La transaction
		return actions.order.create({
			purchase_units: [{
				items: produits,
				amount: {
					value: total_amount,
					currency_code: "USD",
					breakdown: {
						item_total: { value: total_amount, currency_code: "USD" }
					}
				}
			}]
		});
	},

	// 4. Capturer la transaction après l'approbation de l'utilisateur
	onApprove: function (data, actions) {
		return actions.order.capture().then(function (details) {
			console.log(details)
			window.location.replace("SuccessPage")
		})
	},

	// 5. Annuler la transaction
	onCancel: function (data) {
		alert("Transaction annulée !");
	}

}).render("#paypal-boutons");