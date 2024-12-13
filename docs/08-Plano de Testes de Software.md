# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>


 <!--Etapa 3-->
| **Caso de Teste 01** 	| **CT-01 – Listar Ingredientes** |
|:---:	|:---:	|
|	Requisito(s) Associado(s) 	| RF-01 - A aplicação deve permitir ao usuário listar os ingredientes disponíveis em sua casa.<br> RF-02 -	A aplicação deve permitir ao usuário buscar por ingredientes para adicioná-los à sua lista de ingredientes disponíveis.|
| Objetivo do Teste 	| Verificar se o usuário consegue listar os ingredientes que possui em casa e se consegue achá-los rapidamente usando a busca. |
| Passos 	| - Acessar o site <br> - Ir até "Procure or Ingredientes" <br> - Clicar na categoria "Frutas" <br> - Clicar em "Banana" <br> - Clicar na barra de pesquisa <br> - Digitar "Chocolate" <br> - Clicar em "Chocolate" <br> |
|Critério de Êxito | - Os ingredientes selecionados aparecerão em "Meus Ingredientes" |

<!--Etapa 4-->
| **Caso de Teste 02** 	| **CT-02 - Filtrar e Procurar Receitas**	| 
|:---:	|:---:	|
| **Requisito(s) Associado(s)** | RF-03: A aplicação deve permitir ao usuário buscar por receitas. <br>RF-04: A aplicação deve sugerir receitas ao usuário com base em seus ingredientes disponíveis. <br>RF-08: A aplicação deve ocultar receitas que contenham ingredientes que o usuário tenha marcado como ocultos, ou que sejam incompatíveis com seu perfil alimentar.|
| **Objetivo do Teste** 	| Verificar se o site exibe somente as receitas que estejam de acordo com a pesquisa, contendo os alimentos disponíveis inseridos pelo usuário, além de não mostrar receitas com ingredientes ocultados pelo usuário. |
| **Passos** 	| - Acessar o site <br> - Realizar login com o e-mail 'teste123@gmail.com' e senha 'teste123' <br> - Pesquisar pela receita 'Ovo Frito' <br> - Acessar a receita 'Ovo Frito' <br> - Verificar ingredientes: 'Azeite de oliva' e 'Ovo de Galinha' <br> - Clicar no ícone de "Meu Perfil" <br> - Ocultar o ingrediente 'Azeite de Oliva' <br> - Clicar na logo para voltar à tela inicial <br> - Pesquisar novamente a receita 'Ovo Frito' e verificar a ausência da receita <br> - Apagar texto do campo de pesquisa e pesquisar novamente para exibir todas as receitas <br> - Selecionar o ingrediente 'Ovo' na barra lateral esquerda, na categoria 'Outros' <br> - Verificar a presença das receitas: 'Massa de Panqueca', 'Bolo de Cenoura' e 'Macarrão à Carbonara' | Acessar cada receita e notar presença do ingrediente 'Ovo' |
| **Critério de Êxito** | O site deve filtrar, no momento em que os itens forem adicionados à dispensa/ocultados, e exibir somente as receitas que incluem ingredientes na dispensa, excluindo ingredientes ocultados pelo usuário. |


 <!--Etapa 3-->
| **Caso de Teste 03** | **CT-03 - Cadastro e Login** |
|:---:	|:---:	|
| Requisito Associado | RF-06 - A aplicação deve possibilitar o cadastro de contas de usuário. <br> RF-07 - A aplicação deve possibilitar o login de contas de usuário. |
| Objetivo do Teste 	| Verificar se o sistema permite que os usuários realizem o cadastro de conta e o login corretamente. |
| Passos 	| - Acessar o site <br> - Clicar na opção "Cadastrar-se" <br> - Preencher os campos Nome, Email e Senha com:" Teste, Teste@gmail.com, Teste123 <br> - Confirmar o cadastro <br> - Acessar a página de login <br> - Informar e-mail e senha cadastrados <br> - Confirmar o login |
|Critério de Êxito | - O sistema deve exibir uma mensagem de sucesso e redirecionar o usuário para a página de login após o cadastro. - O sistema deve permitir o login com as credenciais cadastradas e redirecionar o usuário para a página inicial após o login bem-sucedido.|

<!--Etapa 3-->
| **Caso de Teste 04** | **CT-04 - Adicionar Receita** | 
|:---: |:---: |
| Requisito Associado | RF-10 - A aplicação deve permitir ao usuário logado adicionar novas receitas ao sistema. |
| Objetivo do Teste | Verificar se o usuário logado consegue adicionar uma nova receita ao sistema com sucesso. |
| Passos | - Acessar o site. <br> - Fazer login com as credenciais: <br>  - E-mail: Teste@gmail.com <br>- Senha: Teste123 <br> - Clicar no botão "Adicionar Receita". <br> - Preencher os campos obrigatórios com as seguintes informações: <br>- **Título:** Teste <br>- **Descrição:** Teste <br>- **Tempo:** 30:00 <br>- **Rendimento:** 5 <br>- **Dificuldade:** Intermediário <br>- **Categoria:** Prato Principal <br>- **Ingredientes:** Banana (1 unidade), Chocolate (200 gramas) <br>- **Modo de Preparo:** Teste1, Teste2 <br> - Confirmar a adição clicando em "Create"|
| Critério de Êxito | - A nova receita, "Teste," deve aparecer na lista de receitas disponíveis. |

<!--Etapa 4-->
| **Caso de Teste 05**	| **CT05 - Editar  receita criada**	| 
|:---:	|:---:	|
|Requisito Associado | RF-11 - A aplicação deve permitir ao usuário logado editar as receitas que ele adicionou ao sistema. |
| Objetivo do Teste 	| Verificar se o usuário consegue editar as receitas que havia criado anteriormente. |
| Passos 	| - Acessar o site; <br> - Fazer login com email "teste@gmail.com" e senha "Teste123"; <br> - Acessar uma receita que não criou e notar ausência do ícone de editar; <br> - Acessar uma receita que criou e clicar no ícone de editar <br> - Alterar os campos "Nome" e "Descrição", "Rendimento", "Dificuldade" e "Tempo de Preparo", modificar os "Passos", a lista de "Ingredietes" e a "Foto da Receita" <br> - Clicar no botão de "Enviar as alterações" <br> - Verificar novas alterações na página de detalhes da receita modificada. |
|Critério de Êxito | - O sistema deve atualizar a receita com as novas informações após o usuário ter enviado as alterações |

<!--Etapa 4-->
| **Caso de Teste 06**	| **CT06 - Excluir receita criada**	| 
|:---:	|:---:	|
|Requisito Associado | RF-12 -	A aplicação deve permitir ao usuário logado excluir as receitas que ele adicionou ao sistema. |
| Objetivo do Teste 	|  Verificar se o usuário consegue excluir as receitas que havia criado anteriormente. |
| Passos 	| -  Acessar o site <br> - Fazer login em uma conta existente <br> - Acessar página "Minhas Receitas" (ícone de livro) <br> - Encontrar seção "Receitas Criadas" <br> - Clicar no botão de remover (ícone de lixeira) <br> - Confirmar a exclusão permanente da receita <br> |
|Critério de Êxito | - A receita não deve estar mais disponível no banco de dados do sistema |

<!--Etapa 3-->
| **Caso de Teste 07**	| **CT07 - Salvar receitas**	| 
|:---:	|:---:	|
|Requisito Associado | RF-13 - A aplicação deve permitir ao usuário logado salvar suas receitas favoritas. |
| Objetivo do Teste 	| Verificar se o usuário consegue salvar uma receita. |
| Passos 	| - Acessar o site <br> - Fazer login com uma conta existente <br> - Acessar a página inicial  <br> - Acessar a receita "Misto Quente Crocante" <br> - Clicar no botão em formato de marcador para salvar <br> |
|Critério de Êxito | - O sistema deve salvar a receita no banco de dados. |

 <!--Etapa 3-->
| **Caso de Teste 09**	| **CT09 - Filtrar receitas por categorias**	|
|:---:	|:---:	|
|Requisito Associado | RF-05	- A aplicação deve permitir ao usuário filtrar receitas por categorias ao buscá-las. |
| Objetivo do Teste 	| Verificar se o sistema filtra corretamente as receitas pelas categorias selecionadas pelo usuário. |
| Passos 	| - Acessar o site <br> - Selecionar as categorias desejadas para filtrar as receitas.|
|Critério de Êxito | - O site deve mostrar apenas as receitas relacionadas a categoria selecionada. |

 <!--Etapa 4-->
| **Caso de Teste 10**	| **CT10 - Preferências Alimentares do Usuário**	|
|:---:	|:---:	|
|Requisito Associado | RF-09	- A aplicação deve permitir ao usuário logado incluir suas restrições alimentares ao seu perfil (vegano, vegetariano, sem glúten, sem lactose e etc). |
| Objetivo do Teste 	| Verificar se o sistema oculta corretamente as receitas e ingredientes que são incompatíveis com as restrições alimentares definidas no perfil do usuário. |
| Passos 	| - Acessar o site <br> - Fazer login com uma conta existente. <br> - Digite "bolo" na barra de pesquisa no header <br> - Veja se a receita "Bolo de cenoura" está aparecendo <br> - Navegue até a seção "Perfil" (ícone de usuário) no header. <br> - Clique na dieta "Sem Açúcar" <br> - Volte para a página inicial clicando na logo no header <br> - Digite "bolo" na barra de pesquisa no header <br> - Veja se a receita "Bolo de cenoura" está aparecendo <br>|
|Critério de Êxito | - A receita "Bolo de cenoura" não deve mais estar aparecendo.|

 <!--Etapa 4-->
| **Caso de Teste 11**	| **CT11 - Adicionar novo ingrediente à banco de dados**	|
|:---:	|:---:	|
|Requisito Associado | RF-15	- A aplicação deve permitir que o usuário logado inclua novos ingredientes na banco de dados. |
| Objetivo do Teste 	| Verificar se o usuário consegue, de forma rápida e simples,  incluir de novos ingredientes à banco de dados. |
| Passos 	| - Acessar o site <br> - Fazer login com uma conta existente. <br> - Navegar até a Página Inicial <br> - Abaixo dos ingredientes clicar em "Não encontrou o ingrediente que procura? Clique aqui" <br> - Preencher os campos obrigatórios com os dados do novo ingrediente (nome = Fermento Biológico, categoria = Outros). <br> - Clicar em "Enviar" |
|Critério de Êxito | - Se campos forém validados, o novo ingrediente será incluído na banco de dados. |

<!--Etapa 3-->
| **Caso de Teste 12**	| **CT12 - Avaliar receitas**	| 
|:---:	|:---:	|
|Requisito Associado | RF-16	- A aplicação deve permitir ao usuário logado avaliar receitas. |
| Objetivo do Teste 	| Verificar se um usuário logado consegue avaliar receitas e se o sistema irá processar essa avaliação. |
| Passos 	| - Acessar o site <br> - Fazer login com as credenciais: Teste2@gmail.com, teste321 <br> - Acessar a receita: "Misto Quente Crocante" <br> - Avaliar a receita em 3 estrelas <br> -  Clicar em "Enviar" |
|Critério de Êxito | - O sistema deve indicar ao usuário que sua avaliação foi publicada. <br> - A avaliação geral da receita deve ser atualizada com base na nova avaliação adicionada |

<!--Etapa 4-->
| **Caso de Teste 13**	| **CT13 - Comentar receitas**	| 
|:---:	|:---:	|
|Requisito Associado | RF-17	- A aplicação deve permitir ao usuário deixar comentários em receitas. |
| Objetivo do Teste 	| Verificar se um usuário logado pode publicar comentários em receitas. |
| Passos 	| - Acessar o site <br> - Fazer login com uma conta existente <br> - Acessar a página inicial  <br> - Acessar a receita desejada <br> - Clicar em "Escreva um comentário" <br> - Escrever um comentário <br> -  Clicar em "Postar" |
|Critério de Êxito | - O sistema deve adicionar o comentário à sessão de comentários da receita. |

<!--Etapa 4-->
| **Caso de Teste 14**	| **CT14 - Administrador deletar ingredientes**	| 
|:---:	|:---:	|
|Requisito Associado | RF-21	- A aplicação deve permitir ao usuário administrador remover ingredientes da banco de dados. |
| Objetivo do Teste 	| Permitir que apenas o administrador possa deletar ingredientes no banco de dados conforme necessidade.|
| Passos 	| - Acessar o site <br> - Fazer login com uma conta de administrador <br> - Acessar a página Meu Perfil <br> - Clicar no botão "Lista de Ingredientes" <br> - Remover o ingrediente "Banana" .
|Critério de Êxito | - O ingrediente deve deixar de ser visível no sistema. |

 <!--Etapa 4-->
| **Caso de Teste 15**	| **CT15 - Administrador deletar receitas**	|
|:---:	|:---:	|
|Requisito Associado | RF-18	- A aplicação deve permitir ao usuário administrador remover receitas da banco de dados. |
| Objetivo do Teste 	| Permitir que apenas o administrador possa deletar receitas na banco de dados conforme necessidade. |
| Passos 	| - Acessar o site <br> - Fazer login com uma conta de administrador <br> - Selecionar uma receita na página inicial ou após uma busca <br> - Clicar no botão de remover ingrediente(ícone de lixeira). <br> - Confirmar a exclusão permanente da receita |
|Critério de Êxito | - A receita não deve estar mais disponível no banco de dados do sistema. |

<!--Etapa 4-->
| **Caso de Teste 16**	| **CT16 - Administrador editar receitas**	| 
|:---:	|:---:	|
|Requisito Associado | RF-19	- A aplicação deve permitir ao usuário administrador editar receitas da banco de dados. |
| Objetivo do Teste 	| Permitir que apenas o administrado possa editar receitas na banco de dados conforme necessidade. |
| Passos 	|- Acessar o site; <br> - Fazer login com email "admin@gmail.com" e senha "admin123"; <br> - Acessar uma receita que não criou e clicar no ícone de editar; <br> - Alterar os campos "Nome" e "Descrição", "Rendimento", "Dificuldade" e "Tempo de Preparo", modificar os "Passos", a lista de "Ingredietes" e a "Foto da Receita" <br> - Clicar no botão de "Enviar as alterações" <br> - Verificar novas alterações na página de detalhes da receita de outro usuário modificada.|
|Critério de Êxito | - O sistema deve atualizar a receita com as novas informações fornecidas pelo administrador após ter enviado as alterações. |

 <!--Etapa 4-->
| **Caso de Teste 17**	| **CT17 - Administrador remover comentários e respostas**	|
|:---:	|:---:	|
|Requisito Associado | RF-20	- A aplicação deve permitir ao usuário administrador remover comentários e respostas da banco de dados. |
| Objetivo do Teste 	| Permitir o administrado possa remover comentários e respostas|
| Passos 	| - Acessar o site <br> - Fazer login com uma conta de administrador (E-mail: admin@gmail.com / Senha:admin123) <br> - Selecionar a receita "Sex on the Beach" na página inicial ou após uma busca <br> - Role a página até o final <br>  - Clicar no botão de deletar do comentário "Gente, façam esse drink! É viciante." (ícone de lixeira). |
|Critério de Êxito | - O comentário "Gente, façam esse drink! É viciante." não deve mais estar visível na receita "Sex on th beach" |


<!--Etapa 4-->
| **Caso de Teste 18**	| **CT18 - Planejar receitas**	| 
|:---:	|:---:	|
|Requisito Associado | RF-14 - A aplicação deve permitir ao usuário logado adicionar receitas ao calendário de planejamento. |
| Objetivo do Teste 	| Verificar se o usuário consegue planejar uma receita salva. |
| Passos 	| - Acessar o site <br> - Fazer login com uma conta existente <br> - Acessar a página inicial  <br> - Acessar a página de receitas salvas pelo cabeçalho da página <br> - Clicar no botão "Adc. ao calendário" <br> - Selecionar um dia válido no calendário <br> |
|Critério de Êxito | - O sistema deve salvar a receita no banco de dados e exibi-la abaixo do calendário com a data escolhida. |
