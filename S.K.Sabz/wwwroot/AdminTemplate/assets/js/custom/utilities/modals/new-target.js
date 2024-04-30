"use strict";

var KTModalNewTarget = (function () {
    var modal, submitBtn, cancelBtn, form, tagify, validation;

    return {
        init: function () {
            modal = document.querySelector("#kt_modal_new_target");

            if (!modal) return;

            var modalInstance = new bootstrap.Modal(modal);

            form = document.querySelector("#kt_modal_new_target_form");
            submitBtn = document.getElementById("kt_modal_new_target_submit");
            cancelBtn = document.getElementById("kt_modal_new_target_cancel");

            tagify = new Tagify(form.querySelector('[name="tags"]'), {
                whitelist: ["Important", "Urgent", "High", "Medium", "Low"],
                maxTags: 5,
                dropdown: {
                    maxItems: 10,
                    enabled: 0,
                    closeOnSelect: false
                }
            });

            tagify.on("change", function () {
                validation.revalidateField("tags");
            });

            $(form.querySelector('[name="due_date"]')).flatpickr({
                enableTime: true,
                dateFormat: "d, M Y, H:i"
            });

            $(form.querySelector('[name="team_assign"]')).on("change", function () {
                validation.revalidateField("team_assign");
            });

            validation = FormValidation.formValidation(form, {
                fields: {
                    target_title: {
                        validators: {
                            notEmpty: {
                                message: "عنوان اجباری"
                            }
                        }
                    },
                    target_assign: {
                        validators: {
                            notEmpty: {
                                message: "تعیین هدف مورد نیاز است"
                            }
                        }
                    },
                    target_due_date: {
                        validators: {
                            notEmpty: {
                                message: "تاریخ سررسید هدف مورد نیاز است"
                            }
                        }
                    },
                    target_tags: {
                        validators: {
                            notEmpty: {
                                message: "برچسب های هدف مورد نیاز است"
                            }
                        }
                    },
                    "targets_notifications[]": {
                        validators: {
                            notEmpty: {
                                message: "لطفاً حداقل یک روش ارتباطی را انتخاب کنید"
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
                                    text: "با موفقیت ثبت شد!",
                                    icon: "success",
                                    buttonsStyling: false,
                                    confirmButtonText: "باشه فهمیدم!",
                                    customClass: {
                                        confirmButton: "btn btn-primary"
                                    }
                                }).then(function (result) {
                                    if (result.isConfirmed) {
                                        modalInstance.hide();
                                        window.location.reload();
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
    KTModalNewTarget.init();
});