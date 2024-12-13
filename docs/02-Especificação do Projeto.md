# Especificações do Projeto

## Personas 

<table>
  <tr>
    <th>Persona 1</th>
    <th><strong>Maria - 34 anos - Mãe Ocupada</strong></th>
  </tr>
  <tr>
    <td><img src="img/Persona1.jpg" alt="Maria" width="200"/></td>
    <td>
      • <strong>Descrição:</strong> Maria Helena de Oliveira - 34 anos<br><br>
      • <strong>Ocupação:</strong> Professora de ensino fundamental e mãe de dois filhos<br><br>
      • <strong>Frustrações:</strong> Falta de tempo para planejar refeições complexas e de ir ao mercado muitas vezes, desperdício de ingredientes que não foram usados e a necessidade de adaptar receitas para atender às restrições alimentares de cada membro da família.<br><br>
      • <strong>Motivações:</strong> Quer otimizar seu tempo na cozinha e evitar desperdícios, além de ensinar hábitos alimentares saudáveis aos filhos.<br><br>
      • <strong>Objetivo no Site:</strong> Encontrar receitas rápidas e fáceis para preparar refeições saudáveis para sua família, usando os ingredientes que já tem em casa.
    </td>
  </tr>

  <tr>
    <th>Persona 2</th>
    <th><strong>Lucas - 26 anos - Estudante Universitário</strong></th>
  </tr>
  <tr>
    <td><img src="img/Persona2.jpg" alt="Lucas" width="200"/></td>
    <td>
      • <strong>Descrição:</strong> Lucas Campos Rocha - 26 anos<br><br>
      • <strong>Ocupação:</strong> Estudante de medicina, mora sozinho<br><br>
      • <strong>Frustrações:</strong> Insegurança na cozinha, falta de experiência com receitas mais elaboradas.<br><br>
      • <strong>Motivações:</strong> Aprender a cozinhar novas receitas e ter uma alimentação equilibrada.<br><br>
      • <strong>Objetivo no Site:</strong> Descobrir e salvar receitas que possam ser preparadas com o que tem na despensa.
    </td>
  </tr>
  <tr>
    <th>Persona 3</th>
    <th><strong>Ana - 42 anos - Vegana</strong></th>
  </tr>
  <tr>
    <td><img src="img/Persona3.jpg" alt="Ana" width="200"/></td>
    <td>
      • <strong>Descrição:</strong> Ana Paula Figueiredo - 42 anos<br><br>
      • <strong>Ocupação:</strong> Designer gráfico e ativista ambiental<br><br>
      • <strong>Frustrações:</strong> Dificuldade em encontrar receitas veganas criativas que utilizem ingredientes acessíveis e baratos.<br><br>
      • <strong>Motivações:</strong> Manter uma dieta vegana saudável e inspirar outros a adotarem uma alimentação mais consciente e sustentável.<br><br>
      • <strong>Objetivo no Site:</strong> Encontrar e compartilhar receitas veganas que sejam sustentáveis e saborosas, além de descobrir novas substituições para ingredientes de origem animal.
    </td>
  </tr>
  
  <tr>
    <th>Persona 4</th>
    <th><strong>João - 55 anos - Chef Aposentado (Administrador)</strong></th>
  </tr>
  <tr>
    <td><img src="img/Persona4.jpg" alt="João" width="200"/></td>
    <td>
      • <strong>Descrição:</strong> João Batista Cordeiro - 55 anos<br><br>
      • <strong>Ocupação:</strong> Chef de cozinha aposentado e agora administrador da plataforma Pratododia<br><br>
      • <strong>Frustrações:</strong> Falta de engajamento e reconhecimento em plataformas mais tradicionais de compartilhamento de receitas.<br><br>
      • <strong>Motivações:</strong> Continuar sua paixão pela culinária, agora em um ambiente mais descontraído, e ensinar novas gerações de cozinheiros amadores.<br><br>
      • <strong>Objetivo no Site:</strong> Compartilhar suas receitas e técnicas culinárias com outros usuários e gerenciar as solicitações de novos ingredientes feitas pelos usuários.
    </td>
  </tr>
  
  <tr>
    <th>Persona 5</th>
    <th><strong>Elisabete - 31 anos - Intolerante à Lactose</strong></th>
  </tr>
  <tr>
    <td><img src="img/Persona5.jpg" alt="Elisabete" width="200"/></td>
    <td>
      • <strong>Descrição:</strong> Elisabete dos Anjos Leite - 31 anos<br><br>
      • <strong>Ocupação:</strong> Analista de marketing<br><br>
      • <strong>Frustrações:</strong> Dificuldade em adaptar receitas tradicionais para versões sem lactose e a frustração de encontrar poucas opções de receitas que atendam suas necessidades alimentares.<br><br>
      • <strong>Motivações:</strong> Evitar desconfortos causados pela intolerância à lactose e encontrar alternativas para ingredientes lácteos sem comprometer o sabor das receitas.<br><br>
      • <strong>Objetivo no Site:</strong> Descobrir e preparar receitas saborosas que não contenham laticínios, garantindo que suas refeições sejam seguras e agradáveis ao paladar.
    </td>
  </tr>
</table>


## Histórias de Usuários

Com base na análise das personas foram identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
| Maria | Planejar melhor as refeições de casa. | Otimizar meu tempo para outras atividades. | <!-- RF-013 -->
| Maria | Encontrar receitas com base nos ingredientes que tenho em casa. | Evitar muitas visitas ao mercado e o desperdício de ingredientes. | <!-- RF-001, RF-002, RF-004 -->
| Lucas | Encontrar receitas variadas de maneira rápida e eficiente. | Aprender a cozinhar pratos diferentes. | <!-- RF-003 -->
| Lucas | Salvar as receitas que achei interessante. | Usá-las quando estiver sem inspiração. | <!-- RF-012 -->
| Ana | Filtrar receitas que não contenham alimentos de origem animal. | Ter mais opções de refeições veganas. | <!-- RF-005, RF-009 -->
| Ana | Incluir novos ingredientes veganos no banco de dados. | Ter mais ingredientes variados e adequados ao meu estilo de vida. | <!-- RF-014 -->
| João | Partilhar minhas receitas. | Ensinar as novas gerações de cozinheiros amadores. | <!-- RF-010. RF-011 -->
| João | Compartilhar dicas de culinária avaliando receitas. | Dividir meu conhecimento na área. | <!-- RF-017 -->
| João | Remover ingredientes incorretos no banco de dados. |  Garantir que todos os ingredientes adicionados atendam aos padrões de qualidade e relevância do sistema. | <!-- RF-015, RF-022 -->
| João | Remover receitas incorretas no banco de dados. |  Garantir que todos as receitas adicionadas atendam aos padrões de qualidade e relevância do sistema. | <!-- RF-020, RF-019 -->
| João | Remover os comentários e respostas impróprios na banco dados. |  Identificar comentários e respostas inadequados e abusivos no sistema. | <!-- RF-021 -->
| Elisabete | Indicar minha intolerância à lactose no meu perfil. | Garantir que as receitas sugeridas sejam seguras para a minha saúde. | <!-- RF-008, RF-009 -->
| Elisabete | Comentar adaptações que fiz em receitas que não atendem às minhas preferências. | Compartilhar essas ideias com outros usuários que tenham as mesmas necessidades. | <!-- RF-018 -->


## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.
Descrição quanto à prioridade dos requisitos: 
- Prioridade alta: Requisito obrigatório.
- Prioridade média: Requisito desejável.
- Prioridade baixa: Requisito opcional.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| A aplicação deve permitir ao usuário listar os ingredientes disponíveis em sua casa. | ALTA |
|RF-002| A aplicação deve permitir ao usuário buscar por ingredientes para adicioná-los à sua lista de ingredientes disponíveis. | ALTA |
|RF-003| A aplicação deve permitir ao usuário buscar por receitas. | ALTA |
|RF-004| A aplicação deve sugerir receitas ao usuário com base em seus ingredientes disponíveis. | ALTA |
|RF-005| A aplicação deve permitir ao usuário filtrar receitas por categorias ao buscá-las. | ALTA |
|RF-006| A aplicação deve possibilitar o cadastro de contas de usuário. | ALTA |
|RF-007| A aplicação deve possibilitar o login de contas de usuário. | ALTA |
|RF-008| A aplicação deve ocultar receitas que contenham ingredientes que o usuário tenha marcado como ocultos, ou que sejam incompatíveis com seu perfil alimentar. | ALTA |
|RF-009| A aplicação deve permitir ao usuário logado incluir suas restrições alimentares ao seu perfil (vegano, vegetariano, sem glúten, sem lactose e etc). | ALTA |
|RF-010| A aplicação deve permitir ao usuário logado adicionar novas receitas ao sistema. | ALTA |
|RF-011| A aplicação deve permitir ao usuário logado editar as receitas que ele adicionou ao sistema. | MÉDIA |
|RF-012| A aplicação deve permitir ao usuário logado remover as receitas que ele adicionou ao sistema. | MÉDIA |
|RF-013| A aplicação deve permitir ao usuário logado salvar suas receitas favoritas. | MÉDIA |
|RF-014| A aplicação deve permitir ao usuário logado adicionar receitas ao calendário de planejamento. | MÉDIA |
|RF-015| A aplicação deve permitir que o usuário inclua novos ingredientes no banco de dados. | MÉDIA |
|RF-016| A aplicação deve permitir ao usuário logado avaliar receitas. | BAIXA | 
|RF-017| A aplicação deve permitir ao usuário logado deixar comentários em receitas. | BAIXA | 
|RF-018| A aplicação deve permitir ao usuário administrador remover receitas do banco de dados. | MÉDIA | 
|RF-019| A aplicação deve permitir ao usuário administrador editar receitas do banco de dados. | MÉDIA | 
|RF-020| A aplicação deve permitir ao usuário administrador remover comentários e respostas do banco de dados. | MÉDIA | 
|RF-021| A aplicação deve permitir ao usuário administrador remover ingredientes do banco de dados. | MÉDIA | 

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----
|RNF-001| A aplicação deve ser compatível com os principais navegadores (Chrome, Firefox, Safari, Edge) e dispositivos (desktop, tablet, smartphone). | ALTA | 
|RNF-002| A aplicação deve ter um design responsivo para garantir uma boa experiência em qualquer tamanho de tela. | ALTA | 
|RNF-003| A aplicação deve ser bem documentada e modular, facilitando futuras manutenções e atualizações. |  MÉDIA | 
|RNF-004| A aplicação deve ser capaz de integrar novas funcionalidades sem comprometer a performance. |  MÉDIA | 
|RNF-005| A aplicação deve deve ser intuitiva e fácil de usar, com navegação clara e instruções simples para garantir que qualquer usuário possa utilizá-la. | MÉDIA |
|RNF-006| A aplicação deve processar requisições do usuário em no máximo 10 segundos. | BAIXA | 

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre. |
|02| Apenas seis pessoas participarão do desenvolvimento. |

## Diagrama de Casos de Uso

![image](https://github.com/user-attachments/assets/c06e0586-3688-46dc-ad01-9af8942bfeea)





