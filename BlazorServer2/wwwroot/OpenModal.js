function blazorOpenModal(dialog) {
    if (!dialog.open) {
        dialog.showModal();
    }
    else {
        dialog.close();
    }
}