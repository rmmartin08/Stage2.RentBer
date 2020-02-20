const baseHostApi = "http://localhost:33819/api";

$(
    function () {
        var urlParams = new URLSearchParams(window.location.search);
        ownerId = urlParams.get("ownerId");

        $.ajax(`${baseHostApi}/owners/${ownerId}`)
            .done(renderOwnerPage)
            .fail(function (xhr, status, err) {
                alert("Ajax Failed. Is the backend running? Err:" + status)
            });;
    }
);

function renderOwnerPage(owner) {
    $("#greeting-header").text(`Welcome to the Owner Page, ${owner.FirstName}`)

    $.ajax(`${baseHostApi}/properties?ownerId=${owner.Id}`)
        .done(renderPropertiesList)

    $.ajax(`${baseHostApi}/rentalagreements?ownerId=${owner.Id}`)
        .done(renderRentalAgreementsList)

    $.ajax(`${baseHostApi}/rentalpayments?ownerId=${owner.Id}&dueAfterDate=${new Date().toISOString()}`)
        .done(renderUpcomingPaymentsList)
}

function renderPropertiesList(properties) {
    for (const property of properties) {
        let newPropertyLine = $("<div>");
        newPropertyLine.text(`${property.StreetAddress}, ${property.City} ${property.State} ${property.Zip}`)
        newPropertyLine.addClass("border-bottom")

        $("#properties-div").append(newPropertyLine);
    }
}

function renderRentalAgreementsList(rentalAgreements) {
    let newRentalAgreementDiv = $("<div>");

    $("#current-rentals-div").append(newRentalAgreementDiv);
    for (const rentalAgreement of rentalAgreements) {
        let newRentalAgreementLink = $("<a>");
        newRentalAgreementLink.addClass("d-block");
        newRentalAgreementDiv.append(newRentalAgreementLink);

        $.ajax(`${baseHostApi}/renters/${rentalAgreement.RenterId}`)
            .done(function (renter) {
                newRentalAgreementLink.attr("href", "/renterPage/renterPage.html?renterId=" + renter.Id)
                newRentalAgreementLink.append(`${renter.FirstName} ${renter.LastName}`);
                $.ajax(`${baseHostApi}/properties/${rentalAgreement.PropertyId}`)
                    .done(function (property) {
                        newRentalAgreementLink.append(` at ${property.StreetAddress}`);

                    })
            })
    }
}

function renderUpcomingPaymentsList(payments) {
    for (const payment of payments) {
        let newPaymentLine = $("<div>");
        $("#upcoming-payments-div").append(newPaymentLine);
        $.ajax(`${baseHostApi}/rentalagreements/${payment.RentalAgreementId}`)
            .done(function (rentalAgreement) {
                let dateLine = $("<div>")
                dateLine.text(new Date(payment.DueDate).toLocaleDateString());
                newPaymentLine.append(dateLine);

                let paymentDetails = $("<div>")
                paymentDetails.addClass("pl-4")
                newPaymentLine.append(paymentDetails);

                paymentDetails.text(`$${rentalAgreement.MonthlyRate}`);
                $.ajax(`${baseHostApi}/properties/${rentalAgreement.PropertyId}`)
                    .done(function (property) {
                        paymentDetails.append(` from ${property.StreetAddress}`);
                    })
            });
    }
}