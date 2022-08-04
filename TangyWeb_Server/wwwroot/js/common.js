window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operation Successful", { timeout: 5000 });
    }
    if (type === "error") {
        toastr.success(message, "Operation Failed", { timeout: 5000 });
    }
};

window.Swal = (type, title, text) => {
    if (type === "success") {
        swal(title, text, "success");
    }
    if (type === "failure") {
        swal(title, text, "error");
    }
}
 
window.ShowDeleteConfirmationModal = () => {
    $('#myModal').modal('show');
}
window.HideDeleteConfirmationModal = () => {
    $('#myModal').modal('hide');
}