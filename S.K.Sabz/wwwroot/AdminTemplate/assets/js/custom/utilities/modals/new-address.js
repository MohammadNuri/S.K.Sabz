"use strict";

var KTModalNewAddress = (function () {
    var modal, form, submitBtn, cancelBtn, validation;

    return {
        init: function () {
            modal = document.querySelector("#kt_modal_new_address");

            if (!modal) return;

            var modalInstance = new bootstrap.Modal(modal);

            form = document.querySelector("#kt_modal_new_address_form");
            submitBtn = document.getElementById("kt_modal_new_address_submit");
            cancelBtn = document.getElementById("kt_modal_new_address_cancel");

            $(form.querySelector('[name="country"]')).select2().on("change", function () {
                validation.revalidateField("country");
            });

            validation = FormValidation.formValidation(form, {
                fields: {
                    "first-name": {
                        validators: {
                            notEmpty: {
                                message: "نام و نام خانوادگی الزامی است"
                            }
                        }
                    },
                    "last-name": {
                        validators: {
                            notEmpty: {
                                message: "نام خانوادگی الزامی است"
                            }
                        }
                    },
                    country: {
                        validators: {
                            notEmpty: {
                                message: "کشور مورد نیاز است"
                            }
                        }
                    },
                    address1: {
                        validators: {
                            notEmpty: {
                                message: "آدرس 1 الزامی است"
                            }
                        }
                    },
                    address2: {
                        validators: {
                            notEmpty: {
                                message: "Address 2 is required"
                            }
                        }
                    },
                    city: {
                        validators: {
                            notEmpty: {
                                message: "شهر مورد نیاز است"
                            }
                        }
                    },
                    state: {
                        validators: {
                            notEmpty: {
                                message: "ایالت مورد نیاز است"
                            }
                        }
                    },
                    postcode: {
                        validators: {
                            notEmpty: {
                                message: "کدپستی الزامی است"
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap5({
                        rowSelector: ".fv-row",
                        eleInvalidClass: "",
                        eleValidClass: ""
                    })
                }
            });

            submitBtn.addEventListener("click", function (e) {
                e.preventDefault();
                if (validation) {
                    validation.validate().then(function (status) {
                        console.log("validated!");
                        if (status === "Valid") {
                            submitBtn.setAttribute("data-kt-indicator", "on");
                            submitBtn.disabled = true;
                            setTimeout(function () {
                                submitBtn.removeAttribute("data-kt-indicator");
                                submitBtn.disabled = false;
                                Swal.fire({
                                    text: "فرم با موفقیت ارسال شد!",
                                    icon: "success",
                                    buttonsStyling: false,
                                    confirmButtonText: "باشه فهمیدم!",
                                    customClass: {
                                        confirmButton: "btn btn-primary"
                                    }
                                }).then(function (result) {
                                    if (result.isConfirmed) {
                                        modalInstance.hide();
                                    }
                                });
                            }, 2000);
                        } else {
                            Swal.fire({
                                text: "متأسفیم ، به نظر می رسد برخی خطاها شناسایی شده است ، لطفاً دوباره امتحان کنید.",
                                icon: "error",
                                buttonsStyling: false,
                                confirmButtonText: "باشه فهمیدم!",
                                customClass: {
                                    confirmButton: "btn btn-primary"
                                }
                            });
                        }
                    });
                }
            });

            cancelBtn.addEventListener("click", function (e) {
                e.preventDefault();
                Swal.fire({
                    text: "آیا مطمئن هستید که می خواهید لغو کنید",
                    icon: "warning",
                    showCancelButton: true,
                    buttonsStyling: false,
                    confirmButtonText: "بله ، آن را لغو کنید!",
                    cancelButtonText: "خیر",
                    customClass: {
                        confirmButton: "btn btn-primary",
                        cancelButton: "btn btn-active-light"
                    }
                }).then(function (result) {
                    if (result.value) {
                        form.reset();
                        modalInstance.hide();
                    } else if (result.dismiss === "cancel") {
                        Swal.fire({
                            text: "فرم شما لغو نشده است !.",
                            icon: "error",
                            buttonsStyling: false,
                            confirmButtonText: "باشه فهمیدم!",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        });
                    }
                });
            });
        }
    };
})();

KTUtil.onDOMContentLoaded(function () {
    KTModalNewAddress.init();
});