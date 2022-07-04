function DeletarConcurso(id, nome) {
    let confirmacao = confirm(`Deseja excluir o '${nome}' dos cadastros de Concurso?`)
    if (confirmacao) {
        $.get(`/Concurso/Excluir/${id}`, function () {
            $(`#concurso-${id}`).remove()
            alert("Concurso removido com êxito!")
        }).fail(function () {
            alert("Houve um problema e não foi possível excluir o Concurso")
        })
    }
}