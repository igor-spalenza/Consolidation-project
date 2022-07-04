$(document).ready(function () {
	$("#CPF").mask("999.999.999-99");

	$("#CEP").mask("99.999-999");

	$('#Telefone').mask(behavior, options);

});

function GetCPF() {
	var cpf = $("#CPF").val()
	alert(cpf)
	cpf = cpf.replace('.', '');
	cpf = cpf.replace('-', '');

	if (validaCPF(cpf) == false) {
		cpf.css("border", "2px solid red");
		alert("CPF inválido");
	}
	else {
		BuscarCPF(cpf);
		$("#CPF").css("border", "2px solid green");
	}
}

//function DeletarPessoa(id, nome) {
//    let confirmacao = confirm(`Deseja excluir o '${nome}' dos cadastros de Pessoas?`)
//    if (confirmacao) {
//        $.get(`/Pessoa/Excluir/${id}`, function () {
//            $(`#pessoa-${id}`).remove()
//            alert("Pessoa removida com êxito!")
//        }).fail(function () {
//			alert("Houve um problema e não foi possível excluir a Pessoa")
//        })
//    }
//}

//máscara do input telefone
var behavior = function (val) {
	return val.replace(/\d/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
}, options = {
	onkeypress: function (val, e, field, options) {
		field.mask(behavior.apply({}, arguments), options);
	}
};


//function DeletarPessoa(id, nome) {
//	let confirmacao = confirm(`Deseja excluir o '${nome}' dos cadastros de Pessoas?`)
//	if (confirmacao) {
//		$.get(`/Pessoa/Excluir/${id}`, function () {
//			$(`#pessoa-${id}`).remove()
//			alert("Pessoa removida com êxito!")
//		}).fail(function () {
//			alert("Houve um problema e não foi possível excluir a Pessoa")
//		})
//	}
//}


///VALIDAÇÃO DE CPF


function BuscarCPF(cpf) {
	$.get(`https://localhost:44366/api/Pessoa?cpf=${cpf}`, function (data) {
		$("#PessoaId ").val(data.Nome);
		$("#Nome").val(data.Nome);
		$("#RG").val(data.RG);
		$("#Email").val(data.Email);
		$("#Telefone").val(data.Telefone);
		$("#DataNascimento").val(data.DataNascimento);
		$("#CEP").val(data.CEP);
		$("#Logradouro").val(data.Logradouro);
		$("#Numero").val(data.Numero);
		$("#Complemento").val(data.Complemento);
		$("#Bairro").val(data.Bairro);
		$("#Cidade").val(data.Cidade);
		$("#UF").val(data.UF);
	})
}

function validaCPF(cpf) {

	erro = new String;
	if (cpf.length < 11) erro += "São necessários 11 digitos para verificacao do CPF! \n\n";
	var nonNumbers = /\D/;
	if (nonNumbers.test(cpf)) erro += "Preencha o CPF apenas com numeros! \n\n";
	if (cpf == "00000000000" ||
		cpf == "11111111111" ||
		cpf == "22222222222" ||
		cpf == "33333333333" ||
		cpf == "44444444444" ||
		cpf == "55555555555" ||
		cpf == "66666666666" ||
		cpf == "77777777777" ||
		cpf == "88888888888" ||
		cpf == "99999999999") {
		erro += "Numero de CPF invalido!"
	}
	var a = [];
	var b = new Number;
	var c = 11;
	for (i = 0; i < 11; i++) {
		a[i] = cpf.charAt(i);
		if (i < 9) b += (a[i] * --c);
	}
	if ((x = b % 11) < 2) { a[9] = 0 } else { a[9] = 11 - x }
	b = 0;
	c = 11;
	for (y = 0; y < 10; y++) b += (a[y] * c--);
	if ((x = b % 11) < 2) { a[10] = 0; } else { a[10] = 11 - x; }
	status = a[9] + "" + a[10]
	if ((cpf.charAt(9) != a[9]) || (cpf.charAt(10) != a[10])) {
		erro += "Digito verificador com problema!";
	}
	if (erro.length > 0) {
		return false;
	}
	return true;
}


//VALIDAÇÃO DE NOME
//function ApenasLetras(e, t) {
//	try {
//		if (window.event) {
//			var charCode = window.event.keyCode;
//		} else if (e) {
//			var charCode = e.which;
//		} else {
//			return true;
//		}
//		if (
//			(charCode > 64 && charCode < 91) ||
//			(charCode > 96 && charCode < 123) ||
//			(charCode > 191 && charCode <= 255) // letras com acentos
//		) {
//			return true;
//		} else {
//			return false;
//		}
//	} catch (err) {
//		alert(err.Description);
//	}
//}



