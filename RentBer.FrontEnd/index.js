const baseHostApi = "http://localhost:33819/api";

$(
    function () {
        $.ajax(`${baseHostApi}/owners`)
            .done(function (owners) {
                let ownersSelectElem = $("#owners-select");
                ownersSelectElem.children().remove();

                for (const owner of owners) {
                    let ownerOption = $("<option>");
                    ownerOption.val(owner.Id);
                    ownerOption.text(owner.FirstName + " " + owner.LastName);
                    ownersSelectElem.append(ownerOption);
                }

            })

        $.ajax(`${baseHostApi}/renters`)
            .done(function (renters) {
                let rentersSelectElem = $("#renters-select");
                rentersSelectElem.children().remove();

                for (const renter of renters) {
                    let renterOption = $("<option>");
                    renterOption.val(renter.Id);
                    renterOption.text(renter.FirstName + " " + renter.LastName);
                    rentersSelectElem.append(renterOption);
                }

            });

        $("#add-new-owner-slide-line").click(function() {
            $("#add-new-owner-div").slideToggle();
        })
        $("#add-new-renter-slide-line").click(function() {
            $("#add-new-renter-div").slideToggle();
        })
        $("#go-to-owner-btn").click(function() {
            window.location.href = "/ownerPage/ownerPage.html?ownerId=" + $("#owners-select > option:selected").val()
        })
        $("#go-to-renter-btn").click(function() {
            window.location.href = "/renterPage/renterPage.html?renterId=" + $("#renters-select > option:selected").val()
        })
    }
)