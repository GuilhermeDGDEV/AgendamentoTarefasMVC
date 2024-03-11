(function () {

    // Ativa todos os popover da página
    const popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
    popoverTriggerList.map(popoverTriggerEl => new bootstrap.Popover(popoverTriggerEl));

    // Ativa modal para deletar registro
    const modalDelecao = document.getElementById('modalDelecao');
    if (modalDelecao) {
        modalDelecao.addEventListener('show.bs.modal', event => {
            const button = event.relatedTarget;
            const idTarefa = button.getAttribute('data-bs-tarefa');
            const deleteRoute = modalDelecao.querySelector('#botaoDeletar');
            deleteRoute.href = '/Tarefa/Deletar/' + idTarefa;
        });
    }
    
})();
