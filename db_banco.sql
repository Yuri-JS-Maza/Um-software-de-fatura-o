-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 13-Out-2023 às 17:22
-- Versão do servidor: 10.4.17-MariaDB
-- versão do PHP: 8.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `db_banco`
--
CREATE DATABASE IF NOT EXISTS `db_banco` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `db_banco`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_categoria`
--

CREATE TABLE `tbl_categoria` (
  `id_Categoria` smallint(6) NOT NULL,
  `nome_Categoria` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_categoria`
--

INSERT INTO `tbl_categoria` (`id_Categoria`, `nome_Categoria`) VALUES
(1, 'afgh'),
(2, 'b');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_cliente`
--

CREATE TABLE `tbl_cliente` (
  `id_Cliente` int(11) NOT NULL,
  `nome` varchar(30) DEFAULT NULL,
  `nif_bi` varchar(15) DEFAULT NULL,
  `id_Contacto` int(11) DEFAULT NULL,
  `id_Endereco` int(11) DEFAULT NULL,
  `id_Tipo_Cliente` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_cliente`
--

INSERT INTO `tbl_cliente` (`id_Cliente`, `nome`, `nif_bi`, `id_Contacto`, `id_Endereco`, `id_Tipo_Cliente`) VALUES
(1, 'nbvbnvb', 'bvnvb', 8, 8, 1),
(2, 'Consumidor Final', NULL, NULL, NULL, 1),
(3, 'hgghh', 'hfhjfjg', 9, 9, 1),
(4, 'Consumidor Final', NULL, NULL, NULL, 1),
(5, 'Consumidor Final', NULL, NULL, NULL, 1),
(6, 'Consumidor Final', NULL, NULL, NULL, 1),
(7, 'Consumidor Final', NULL, NULL, NULL, 1),
(8, 'Consumidor Final', NULL, NULL, NULL, 1),
(9, 'Consumidor Final', NULL, NULL, NULL, 1),
(10, 'Consumidor Final', NULL, NULL, NULL, 1),
(11, 'Consumidor Final', NULL, NULL, NULL, 1),
(12, 'Consumidor Final', NULL, NULL, NULL, 1),
(13, 'Consumidor Final', NULL, NULL, NULL, 1),
(14, 'Consumidor Final', NULL, NULL, NULL, 1),
(15, 'Consumidor Final', NULL, NULL, NULL, 1),
(16, 'Kimuanga', '343343', 10, 10, 1),
(17, 'Consumidor Final', NULL, NULL, NULL, 1),
(18, 'ttgffdg', 'fdgdfg', 11, 11, 1),
(19, 'Consumidor Final', NULL, NULL, NULL, 1),
(20, 'jjhj', 'hgjgh', 12, 12, 1),
(21, 'Consumidor Final', NULL, NULL, NULL, 1),
(22, 'Consumidor Final', NULL, NULL, NULL, 1),
(23, 'Consumidor Final', NULL, NULL, NULL, 1),
(24, 'Consumidor Final', NULL, NULL, NULL, 1),
(25, 'Consumidor Final', NULL, NULL, NULL, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_compra`
--

CREATE TABLE `tbl_compra` (
  `id_Compra` int(11) NOT NULL,
  `id_Gestor` smallint(6) DEFAULT NULL,
  `id_Fornecedor` int(11) DEFAULT NULL,
  `total` decimal(10,2) DEFAULT NULL,
  `desconto` decimal(10,2) DEFAULT NULL,
  `valor_Pago` decimal(10,2) DEFAULT NULL,
  `troco` decimal(10,2) DEFAULT NULL,
  `id_Forma_Pagamento` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_contacto`
--

CREATE TABLE `tbl_contacto` (
  `id_Contacto` int(11) NOT NULL,
  `telefone` varchar(14) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_contacto`
--

INSERT INTO `tbl_contacto` (`id_Contacto`, `telefone`, `email`) VALUES
(1, NULL, NULL),
(2, NULL, NULL),
(3, NULL, NULL),
(4, NULL, NULL),
(6, NULL, NULL),
(7, 'jhhjhjhjhj', 'jjoio'),
(8, 'rtrtt', 'trytrt'),
(9, 'hghgg', 'hggh'),
(10, '54445', 'hjgfhh@gmail'),
(11, 'fdgfd', 'fdgdfgdf'),
(12, 'ghjgh', 'hgj');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_endereco`
--

CREATE TABLE `tbl_endereco` (
  `id_Endereco` int(11) NOT NULL,
  `provincia` varchar(20) DEFAULT NULL,
  `municipio` varchar(20) DEFAULT NULL,
  `bairro` varchar(20) DEFAULT NULL,
  `rua` varchar(30) DEFAULT NULL,
  `casa` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_endereco`
--

INSERT INTO `tbl_endereco` (`id_Endereco`, `provincia`, `municipio`, `bairro`, `rua`, `casa`) VALUES
(1, 'ghlg', 'hhhh', 'ghh', 'ghlhl', 'hggh'),
(2, 'jhhjhjjhjh', 'hjhj', 'jjjj', 'hjhj', 'çhjlk'),
(3, 'gjfkjg', 'fghfg', 'gjfjh', 'fggfg', 'gfghj'),
(4, 'jkhjk', 'jhjh', 'jhjjkl', 'hjh', 'hjh'),
(6, NULL, NULL, NULL, NULL, NULL),
(7, 'jhjhjh', 'hhju', 'jhhhjj', 'iiohj', 'hhjj'),
(8, 'trtryhrt', 'bvnvb', 'tryrtrttr', 'frf', 'rttyrt'),
(9, 'ghhghg', 'ghhg', 'ghgh', 'hggh', 'ghhg'),
(10, 'trtr', 'hjhhh', 'tytt', 'hjh', 'fgf'),
(11, 'ffdgd', 'fgddfggfd', 'fdgfdg', 'fgff', 'gfgf'),
(12, 'hjkj', 'jhjkgj', 'hgjhg', 'ghjgh', 'hgjhj');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_forma_pagamento`
--

CREATE TABLE `tbl_forma_pagamento` (
  `id_Forma_Pagamento` smallint(6) NOT NULL,
  `nome_Forma_Pagamento` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_forma_pagamento`
--

INSERT INTO `tbl_forma_pagamento` (`id_Forma_Pagamento`, `nome_Forma_Pagamento`) VALUES
(1, 'Numerário'),
(2, 'Multicaixa'),
(3, 'x');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_fornecedor`
--

CREATE TABLE `tbl_fornecedor` (
  `id_Fornecedor` int(11) NOT NULL,
  `nome` varchar(30) DEFAULT NULL,
  `nif_bi` varchar(15) DEFAULT NULL,
  `id_Contacto` int(11) DEFAULT NULL,
  `id_Endereco` int(11) DEFAULT NULL,
  `id_Tipo_Fornecedor` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_gestor`
--

CREATE TABLE `tbl_gestor` (
  `id_Gestor` smallint(6) NOT NULL,
  `id_Pessoa` smallint(6) DEFAULT NULL,
  `dataAdmissao` date DEFAULT NULL,
  `num_Credencial` varchar(15) DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_gestor`
--

INSERT INTO `tbl_gestor` (`id_Gestor`, `id_Pessoa`, `dataAdmissao`, `num_Credencial`, `status`) VALUES
(2, 7, '2023-08-25', 'ljhjjj', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_itenscompra`
--

CREATE TABLE `tbl_itenscompra` (
  `id_Compra` int(11) NOT NULL,
  `id_Produto` int(11) NOT NULL,
  `preco` decimal(10,2) DEFAULT NULL,
  `quantidade` decimal(5,2) DEFAULT NULL,
  `desconto` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_itens_venda`
--

CREATE TABLE `tbl_itens_venda` (
  `id_Venda` int(11) NOT NULL,
  `id_Produto` int(11) NOT NULL,
  `preco` decimal(10,2) DEFAULT NULL,
  `quantidade` decimal(5,2) DEFAULT NULL,
  `desconto` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_itens_venda`
--

INSERT INTO `tbl_itens_venda` (`id_Venda`, `id_Produto`, `preco`, `quantidade`, `desconto`) VALUES
(4, 1, '69.00', '1.00', '0.00'),
(5, 1, '69.00', '1.00', '0.00'),
(6, 1, '69.00', '1.00', '0.00'),
(7, 1, '69.00', '2.00', '0.00'),
(8, 5, '10.00', '3.00', '10.00'),
(9, 1, '69.00', '1.00', '0.00'),
(10, 1, '69.00', '1.00', '0.00'),
(11, 1, '69.00', '1.00', '0.00'),
(12, 1, '69.00', '1.00', '0.00'),
(13, 1, '69.00', '1.00', '0.00'),
(14, 1, '69.00', '1.00', '0.00'),
(15, 1, '69.00', '3.00', '0.00'),
(16, 1, '69.00', '1.00', '0.00'),
(17, 1, '69.00', '4.00', '0.00'),
(18, 1, '69.00', '10.00', '0.00'),
(19, 1, '69.00', '1.00', '0.00'),
(20, 1, '69.00', '1.00', '0.00'),
(21, 1, '69.00', '8.00', '0.00'),
(21, 4, '10.00', '2.00', '0.00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_marca`
--

CREATE TABLE `tbl_marca` (
  `id_Marca` smallint(6) NOT NULL,
  `nome_Marca` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_marca`
--

INSERT INTO `tbl_marca` (`id_Marca`, `nome_Marca`) VALUES
(1, 'teste'),
(2, 'tfgfg'),
(3, 'bb'),
(4, 'ff');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_modelo`
--

CREATE TABLE `tbl_modelo` (
  `id_Modelo` smallint(6) NOT NULL,
  `nome_Modelo` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_modelo`
--

INSERT INTO `tbl_modelo` (`id_Modelo`, `nome_Modelo`) VALUES
(1, 'gh');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_pessoa`
--

CREATE TABLE `tbl_pessoa` (
  `id_Pessoa` smallint(6) NOT NULL,
  `nome` varchar(30) DEFAULT NULL,
  `sobrenome` varchar(50) DEFAULT NULL,
  `genero` char(1) DEFAULT NULL,
  `bi` varchar(15) DEFAULT NULL,
  `data_nascimento` date DEFAULT NULL,
  `id_Contacto` int(11) DEFAULT NULL,
  `id_Endereco` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_pessoa`
--

INSERT INTO `tbl_pessoa` (`id_Pessoa`, `nome`, `sobrenome`, `genero`, `bi`, `data_nascimento`, `id_Contacto`, `id_Endereco`) VALUES
(1, 'Kimuanga', 'Massuquinina Benza', 'M', 'hkhhh', '2023-08-23', 1, 1),
(2, 'jkklj', 'jlkilj', 'F', 'kjkj', '2023-08-23', 2, 2),
(3, 'Aluno', 'bghhjh', 'M', 'h,gfghhg', '2023-08-24', 3, 3),
(4, 'jjj', 'hjjjj', 'M', 'hjjkl', '2023-08-24', 4, 4),
(6, NULL, NULL, '\0', NULL, '0001-01-01', 6, 6),
(7, 'kjkjj', 'jjkkj', 'M', 'jkkk', '2023-08-25', 7, 7);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_produto`
--

CREATE TABLE `tbl_produto` (
  `id_Produto` int(11) NOT NULL,
  `nome` varchar(30) DEFAULT NULL,
  `descricao` varchar(50) DEFAULT NULL,
  `codigo_Barras` varchar(30) DEFAULT NULL,
  `preco` decimal(10,2) DEFAULT NULL,
  `quantidade` decimal(5,2) DEFAULT NULL,
  `quantidadeMinima` decimal(5,2) DEFAULT NULL,
  `validade` date DEFAULT NULL,
  `id_Categoria` smallint(6) DEFAULT NULL,
  `id_Marca` smallint(6) DEFAULT NULL,
  `id_Modelo` smallint(6) DEFAULT NULL,
  `id_Unidade` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_produto`
--

INSERT INTO `tbl_produto` (`id_Produto`, `nome`, `descricao`, `codigo_Barras`, `preco`, `quantidade`, `quantidadeMinima`, `validade`, `id_Categoria`, `id_Marca`, `id_Modelo`, `id_Unidade`) VALUES
(1, 'gggggggggg67ft', 'gj,hkf', '123', '69.00', '70.00', '10.00', '2023-08-18', NULL, 4, 1, 1),
(4, 'hjhhj', 'hjkj', '1234', '10.00', '8.00', '10.00', '2023-08-24', NULL, 2, 1, 2),
(5, 'hjhhj', 'hjkj', '12345', '10.00', '10.00', '10.00', '2023-08-24', NULL, 1, 1, 2);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_sistema`
--

CREATE TABLE `tbl_sistema` (
  `id_Sistema` int(11) NOT NULL,
  `nome` varchar(30) DEFAULT NULL,
  `descricao` varchar(50) DEFAULT NULL,
  `nif` varchar(15) DEFAULT NULL,
  `id_Contacto` int(11) DEFAULT NULL,
  `id_Endereco` int(11) DEFAULT NULL,
  `logo` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_temp_produto`
--

CREATE TABLE `tbl_temp_produto` (
  `Id_Produto_Temp` int(11) NOT NULL,
  `id_Produto` int(11) NOT NULL,
  `quantidade` decimal(5,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_temp_produto`
--

INSERT INTO `tbl_temp_produto` (`Id_Produto_Temp`, `id_Produto`, `quantidade`) VALUES
(1, 1, '2.00'),
(2, 1, '2.00'),
(3, 4, '2.00'),
(4, 4, '1.00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_tipo_cliente_fornecedor`
--

CREATE TABLE `tbl_tipo_cliente_fornecedor` (
  `id_Tipo_Cliente_Fornecedor` tinyint(4) NOT NULL,
  `nome` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_tipo_cliente_fornecedor`
--

INSERT INTO `tbl_tipo_cliente_fornecedor` (`id_Tipo_Cliente_Fornecedor`, `nome`) VALUES
(1, 'Físico'),
(2, 'Jurídico');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_unidade`
--

CREATE TABLE `tbl_unidade` (
  `id_Unidade` smallint(6) NOT NULL,
  `nome_Unidade` varchar(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_unidade`
--

INSERT INTO `tbl_unidade` (`id_Unidade`, `nome_Unidade`) VALUES
(1, 'L'),
(2, 'ml');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_usuario`
--

CREATE TABLE `tbl_usuario` (
  `id_Usuario` smallint(6) NOT NULL,
  `usuario` varchar(30) DEFAULT NULL,
  `senha` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_usuario`
--

INSERT INTO `tbl_usuario` (`id_Usuario`, `usuario`, `senha`) VALUES
(1, 'Kimuanga', '202cb962ac59075b964b07152d234b70');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_usuario_gestor`
--

CREATE TABLE `tbl_usuario_gestor` (
  `id_Gestor` smallint(6) NOT NULL,
  `id_Usuario` smallint(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_usuario_vendedor`
--

CREATE TABLE `tbl_usuario_vendedor` (
  `id_Vendedor` smallint(6) NOT NULL,
  `id_Usuario` smallint(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_usuario_vendedor`
--

INSERT INTO `tbl_usuario_vendedor` (`id_Vendedor`, `id_Usuario`) VALUES
(1, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_venda`
--

CREATE TABLE `tbl_venda` (
  `id_Venda` int(11) NOT NULL,
  `id_Vendedor` smallint(6) DEFAULT NULL,
  `id_Cliente` int(11) DEFAULT NULL,
  `total` decimal(10,2) DEFAULT NULL,
  `desconto` decimal(10,2) DEFAULT NULL,
  `valor_Pago` decimal(10,2) DEFAULT NULL,
  `troco` decimal(10,2) DEFAULT NULL,
  `id_Forma_Pagamento` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_venda`
--

INSERT INTO `tbl_venda` (`id_Venda`, `id_Vendedor`, `id_Cliente`, `total`, `desconto`, `valor_Pago`, `troco`, `id_Forma_Pagamento`) VALUES
(1, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(2, 1, 6, '10.00', '10.00', '10.00', '0.00', 2),
(3, 1, 7, '10.00', '10.00', '10.00', '0.00', 2),
(4, 1, 8, '10.00', '10.00', '10.00', '0.00', 2),
(5, 1, 9, '69.00', '0.00', '0.00', '0.00', 2),
(6, 1, 10, '69.00', '0.00', '100.00', '0.00', 2),
(7, 1, 11, '138.00', '0.00', '200.00', '0.00', 1),
(8, 1, 12, '197.00', '10.00', '200.00', '3.00', 1),
(9, 1, 13, '69.00', '0.00', '100.00', '31.00', 2),
(10, 1, 14, '69.00', '0.00', '200.00', '131.00', 2),
(11, 1, 15, '69.00', '0.00', '2000.00', '1931.00', 2),
(12, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(13, 1, 17, '69.00', '0.00', '100.00', '31.00', 2),
(14, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(15, 1, 19, '207.00', '0.00', '1000.00', '793.00', 1),
(16, 1, 20, '69.00', '0.00', '100.00', '31.00', 2),
(17, 1, 21, '276.00', '0.00', '1000.00', '724.00', 1),
(18, 1, 22, '690.00', '0.00', '1000.00', '310.00', 2),
(19, 1, 23, '69.00', '0.00', '70.00', '1.00', 2),
(20, 1, 24, '69.00', '0.00', '100.00', '31.00', 1),
(21, 1, 25, '572.00', '0.00', '1000.00', '428.00', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_vendedor`
--

CREATE TABLE `tbl_vendedor` (
  `id_Vendedor` smallint(6) NOT NULL,
  `id_Pessoa` smallint(6) DEFAULT NULL,
  `dataAdmissao` date DEFAULT NULL,
  `num_Credencial` varchar(15) DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tbl_vendedor`
--

INSERT INTO `tbl_vendedor` (`id_Vendedor`, `id_Pessoa`, `dataAdmissao`, `num_Credencial`, `status`) VALUES
(1, 1, '2023-08-23', 'ghhgh', 1),
(2, 3, '2023-08-24', 'gfgfggf', 0),
(3, 4, '2023-08-24', 'jkhjkl', 1);

-- --------------------------------------------------------

--
-- Estrutura stand-in para vista `vwcliente`
-- (Veja abaixo para a view atual)
--
CREATE TABLE `vwcliente` (
`Código` int(11)
,`Nome` varchar(30)
,`NIF/BI` varchar(15)
,`Código Contacto` int(11)
,`Telefone` varchar(14)
,`Email` varchar(50)
,`Código Endereço` int(11)
,`Província` varchar(20)
,`Município` varchar(20)
,`Bairro` varchar(20)
,`Rua` varchar(30)
,`Casa` varchar(10)
,`Código Tipo Cliente` tinyint(4)
,`Tipo Cliente` varchar(20)
);

-- --------------------------------------------------------

--
-- Estrutura stand-in para vista `vwgestor`
-- (Veja abaixo para a view atual)
--
CREATE TABLE `vwgestor` (
`id_Pessoa` smallint(6)
,`Nome` varchar(30)
,`Sobrenome` varchar(50)
,`Gênero` char(1)
,`Nº do Bilhete` varchar(15)
,`Data de Nascimento` date
,`id_Contacto` int(11)
,`Telefone` varchar(14)
,`Email` varchar(50)
,`id_Endereco` int(11)
,`Província` varchar(20)
,`Município` varchar(20)
,`Bairro` varchar(20)
,`Rua` varchar(30)
,`Casa` varchar(10)
,`id_Gestor` smallint(6)
,`Nº do Credencial` varchar(15)
,`Data de Admissão` date
,`Status` tinyint(1)
);

-- --------------------------------------------------------

--
-- Estrutura stand-in para vista `vwinventario`
-- (Veja abaixo para a view atual)
--
CREATE TABLE `vwinventario` (
`Código` int(11)
,`Descrição` varchar(50)
,`Código de Barras` varchar(30)
,`Categoria` varchar(20)
,`Marca` varchar(20)
,`Modelo` varchar(20)
,`Válidade` date
,`Entrada` decimal(27,2)
,`Saida` decimal(27,2)
,`Stock` decimal(5,2)
);

-- --------------------------------------------------------

--
-- Estrutura stand-in para vista `vwitensvenda`
-- (Veja abaixo para a view atual)
--
CREATE TABLE `vwitensvenda` (
`Codigo_Venda` int(11)
,`Codigo_Produto` int(11)
,`Produto` varchar(50)
,`Preco` decimal(10,2)
,`Qtd` decimal(5,2)
,`Desconto` decimal(10,2)
,`Total` decimal(15,4)
);

-- --------------------------------------------------------

--
-- Estrutura stand-in para vista `vwproduto`
-- (Veja abaixo para a view atual)
--
CREATE TABLE `vwproduto` (
`Código` int(11)
,`Nome` varchar(30)
,`Descrição` varchar(50)
,`Código de Barras` varchar(30)
,`Preço` decimal(10,2)
,`Qtd` decimal(5,2)
,`Qtd. Min` decimal(5,2)
,`Válidade` date
,`Código da Categoria` smallint(6)
,`Categoria` varchar(20)
,`Código da Marca` smallint(6)
,`Marca` varchar(20)
,`Código da Unidade` smallint(6)
,`Unidade` varchar(5)
,`Código do Modelo` smallint(6)
,`Modelo` varchar(20)
);

-- --------------------------------------------------------

--
-- Estrutura stand-in para vista `vwusuariogestor`
-- (Veja abaixo para a view atual)
--
CREATE TABLE `vwusuariogestor` (
`id_Gestor` smallint(6)
,`Nome` varchar(80)
,`Status` tinyint(1)
,`Usuário` varchar(30)
,`Senha` text
);

-- --------------------------------------------------------

--
-- Estrutura stand-in para vista `vwusuariovendedor`
-- (Veja abaixo para a view atual)
--
CREATE TABLE `vwusuariovendedor` (
`id_Vendedor` smallint(6)
,`Nome` varchar(80)
,`Status` tinyint(1)
,`Usuário` varchar(30)
,`Senha` text
);

-- --------------------------------------------------------

--
-- Estrutura stand-in para vista `vwvendas`
-- (Veja abaixo para a view atual)
--
CREATE TABLE `vwvendas` (
`Codigo` int(11)
,`Codigo_Vendedor` smallint(6)
,`Vendedor` varchar(81)
,`Codigo_Cliente` int(11)
,`Cliente` varchar(30)
,`NIF_BI_Cliente` varchar(15)
,`Total` decimal(10,2)
,`Desconto` decimal(10,2)
,`Valor_Pago` decimal(10,2)
,`Troco` decimal(10,2)
,`Codigo_FPagamento` smallint(6)
,`FPagamento` varchar(20)
);

-- --------------------------------------------------------

--
-- Estrutura stand-in para vista `vwvendedor`
-- (Veja abaixo para a view atual)
--
CREATE TABLE `vwvendedor` (
`id_Pessoa` smallint(6)
,`Nome` varchar(30)
,`Sobrenome` varchar(50)
,`Gênero` char(1)
,`Nº do B.I` varchar(15)
,`Data de Nascimento` date
,`id_Contacto` int(11)
,`Telefone` varchar(14)
,`Email` varchar(50)
,`id_Endereco` int(11)
,`Província` varchar(20)
,`Município` varchar(20)
,`Bairro` varchar(20)
,`Rua` varchar(30)
,`Casa` varchar(10)
,`id_Vendedor` smallint(6)
,`Credencial` varchar(15)
,`Data de Admissão` date
,`Status` tinyint(1)
);

-- --------------------------------------------------------

--
-- Estrutura para vista `vwcliente`
--
DROP TABLE IF EXISTS `vwcliente`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwcliente`  AS SELECT `cli`.`id_Cliente` AS `Código`, `cli`.`nome` AS `Nome`, `cli`.`nif_bi` AS `NIF/BI`, `cli`.`id_Contacto` AS `Código Contacto`, `c`.`telefone` AS `Telefone`, `c`.`email` AS `Email`, `cli`.`id_Endereco` AS `Código Endereço`, `e`.`provincia` AS `Província`, `e`.`municipio` AS `Município`, `e`.`bairro` AS `Bairro`, `e`.`rua` AS `Rua`, `e`.`casa` AS `Casa`, `tfc`.`id_Tipo_Cliente_Fornecedor` AS `Código Tipo Cliente`, `tfc`.`nome` AS `Tipo Cliente` FROM (((`tbl_cliente` `cli` left join `tbl_contacto` `c` on(`c`.`id_Contacto` = `cli`.`id_Contacto`)) left join `tbl_endereco` `e` on(`e`.`id_Endereco` = `cli`.`id_Endereco`)) left join `tbl_tipo_cliente_fornecedor` `tfc` on(`tfc`.`id_Tipo_Cliente_Fornecedor` = `cli`.`id_Tipo_Cliente`)) ;

-- --------------------------------------------------------

--
-- Estrutura para vista `vwgestor`
--
DROP TABLE IF EXISTS `vwgestor`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwgestor`  AS SELECT `p`.`id_Pessoa` AS `id_Pessoa`, `p`.`nome` AS `Nome`, `p`.`sobrenome` AS `Sobrenome`, `p`.`genero` AS `Gênero`, `p`.`bi` AS `Nº do Bilhete`, `p`.`data_nascimento` AS `Data de Nascimento`, `c`.`id_Contacto` AS `id_Contacto`, `c`.`telefone` AS `Telefone`, `c`.`email` AS `Email`, `e`.`id_Endereco` AS `id_Endereco`, `e`.`provincia` AS `Província`, `e`.`municipio` AS `Município`, `e`.`bairro` AS `Bairro`, `e`.`rua` AS `Rua`, `e`.`casa` AS `Casa`, `g`.`id_Gestor` AS `id_Gestor`, `g`.`num_Credencial` AS `Nº do Credencial`, `g`.`dataAdmissao` AS `Data de Admissão`, `g`.`status` AS `Status` FROM (((`tbl_gestor` `g` join `tbl_pessoa` `p` on(`p`.`id_Pessoa` = `g`.`id_Pessoa`)) left join `tbl_endereco` `e` on(`e`.`id_Endereco` = `p`.`id_Endereco`)) left join `tbl_contacto` `c` on(`c`.`id_Contacto` = `p`.`id_Contacto`)) ;

-- --------------------------------------------------------

--
-- Estrutura para vista `vwinventario`
--
DROP TABLE IF EXISTS `vwinventario`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwinventario`  AS SELECT `p`.`Código` AS `Código`, `p`.`Descrição` AS `Descrição`, `p`.`Código de Barras` AS `Código de Barras`, `p`.`Categoria` AS `Categoria`, `p`.`Marca` AS `Marca`, `p`.`Modelo` AS `Modelo`, `p`.`Válidade` AS `Válidade`, (select sum(`itc`.`quantidade`) from `tbl_itenscompra` `itc` where `itc`.`id_Produto` = `p`.`Código`) AS `Entrada`, (select sum(`itv`.`quantidade`) from `tbl_itens_venda` `itv` where `itv`.`id_Produto` = `p`.`Código`) AS `Saida`, `p`.`Qtd` AS `Stock` FROM `vwproduto` AS `p` ;

-- --------------------------------------------------------

--
-- Estrutura para vista `vwitensvenda`
--
DROP TABLE IF EXISTS `vwitensvenda`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwitensvenda`  AS SELECT `itv`.`id_Venda` AS `Codigo_Venda`, `itv`.`id_Produto` AS `Codigo_Produto`, `p`.`descricao` AS `Produto`, `itv`.`preco` AS `Preco`, `itv`.`quantidade` AS `Qtd`, `itv`.`desconto` AS `Desconto`, `itv`.`preco`* `itv`.`quantidade` AS `Total` FROM (`tbl_itens_venda` `itv` join `tbl_produto` `p` on(`itv`.`id_Produto` = `p`.`id_Produto`)) ;

-- --------------------------------------------------------

--
-- Estrutura para vista `vwproduto`
--
DROP TABLE IF EXISTS `vwproduto`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwproduto`  AS SELECT `p`.`id_Produto` AS `Código`, `p`.`nome` AS `Nome`, `p`.`descricao` AS `Descrição`, `p`.`codigo_Barras` AS `Código de Barras`, `p`.`preco` AS `Preço`, `p`.`quantidade` AS `Qtd`, `p`.`quantidadeMinima` AS `Qtd. Min`, `p`.`validade` AS `Válidade`, `p`.`id_Categoria` AS `Código da Categoria`, `cate`.`nome_Categoria` AS `Categoria`, `p`.`id_Marca` AS `Código da Marca`, `marca`.`nome_Marca` AS `Marca`, `p`.`id_Unidade` AS `Código da Unidade`, `uni`.`nome_Unidade` AS `Unidade`, `p`.`id_Modelo` AS `Código do Modelo`, `model`.`nome_Modelo` AS `Modelo` FROM ((((`tbl_produto` `p` left join `tbl_modelo` `model` on(`p`.`id_Modelo` = `model`.`id_Modelo`)) left join `tbl_categoria` `cate` on(`cate`.`id_Categoria` = `p`.`id_Categoria`)) left join `tbl_marca` `marca` on(`marca`.`id_Marca` = `p`.`id_Marca`)) left join `tbl_unidade` `uni` on(`uni`.`id_Unidade` = `p`.`id_Unidade`)) ;

-- --------------------------------------------------------

--
-- Estrutura para vista `vwusuariogestor`
--
DROP TABLE IF EXISTS `vwusuariogestor`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwusuariogestor`  AS SELECT `g`.`id_Gestor` AS `id_Gestor`, concat(`g`.`Nome`,`g`.`Sobrenome`) AS `Nome`, `g`.`Status` AS `Status`, `u`.`usuario` AS `Usuário`, `u`.`senha` AS `Senha` FROM ((`tbl_usuario_gestor` `ug` join `vwgestor` `g` on(`g`.`id_Gestor` = `ug`.`id_Gestor`)) join `tbl_usuario` `u` on(`u`.`id_Usuario` = `ug`.`id_Usuario`)) ;

-- --------------------------------------------------------

--
-- Estrutura para vista `vwusuariovendedor`
--
DROP TABLE IF EXISTS `vwusuariovendedor`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwusuariovendedor`  AS SELECT `v`.`id_Vendedor` AS `id_Vendedor`, concat(`v`.`Nome`,`v`.`Sobrenome`) AS `Nome`, `v`.`Status` AS `Status`, `u`.`usuario` AS `Usuário`, `u`.`senha` AS `Senha` FROM ((`tbl_usuario_vendedor` `uv` join `vwvendedor` `v` on(`v`.`id_Vendedor` = `uv`.`id_Vendedor`)) join `tbl_usuario` `u` on(`u`.`id_Usuario` = `uv`.`id_Vendedor`)) ;

-- --------------------------------------------------------

--
-- Estrutura para vista `vwvendas`
--
DROP TABLE IF EXISTS `vwvendas`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwvendas`  AS SELECT `vd`.`id_Venda` AS `Codigo`, `vd`.`id_Vendedor` AS `Codigo_Vendedor`, concat(`pv`.`nome`,' ',`pv`.`sobrenome`) AS `Vendedor`, `vd`.`id_Cliente` AS `Codigo_Cliente`, `cli`.`nome` AS `Cliente`, `cli`.`nif_bi` AS `NIF_BI_Cliente`, `vd`.`total` AS `Total`, `vd`.`desconto` AS `Desconto`, `vd`.`valor_Pago` AS `Valor_Pago`, `vd`.`troco` AS `Troco`, `vd`.`id_Forma_Pagamento` AS `Codigo_FPagamento`, `fpag`.`nome_Forma_Pagamento` AS `FPagamento` FROM ((((`tbl_venda` `vd` join `tbl_vendedor` `vdr` on(`vd`.`id_Vendedor` = `vdr`.`id_Vendedor`)) join `tbl_pessoa` `pv` on(`pv`.`id_Pessoa` = `vdr`.`id_Pessoa`)) join `tbl_cliente` `cli` on(`cli`.`id_Cliente` = `vd`.`id_Cliente`)) join `tbl_forma_pagamento` `fpag` on(`fpag`.`id_Forma_Pagamento` = `vd`.`id_Forma_Pagamento`)) ;

-- --------------------------------------------------------

--
-- Estrutura para vista `vwvendedor`
--
DROP TABLE IF EXISTS `vwvendedor`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwvendedor`  AS SELECT `p`.`id_Pessoa` AS `id_Pessoa`, `p`.`nome` AS `Nome`, `p`.`sobrenome` AS `Sobrenome`, `p`.`genero` AS `Gênero`, `p`.`bi` AS `Nº do B.I`, `p`.`data_nascimento` AS `Data de Nascimento`, `p`.`id_Contacto` AS `id_Contacto`, `c`.`telefone` AS `Telefone`, `c`.`email` AS `Email`, `p`.`id_Endereco` AS `id_Endereco`, `e`.`provincia` AS `Província`, `e`.`municipio` AS `Município`, `e`.`bairro` AS `Bairro`, `e`.`rua` AS `Rua`, `e`.`casa` AS `Casa`, `v`.`id_Vendedor` AS `id_Vendedor`, `v`.`num_Credencial` AS `Credencial`, `v`.`dataAdmissao` AS `Data de Admissão`, `v`.`status` AS `Status` FROM (((`tbl_pessoa` `p` left join `tbl_endereco` `e` on(`p`.`id_Endereco` = `e`.`id_Endereco`)) left join `tbl_contacto` `c` on(`p`.`id_Contacto` = `c`.`id_Contacto`)) join `tbl_vendedor` `v` on(`p`.`id_Pessoa` = `v`.`id_Pessoa`)) ;

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `tbl_categoria`
--
ALTER TABLE `tbl_categoria`
  ADD PRIMARY KEY (`id_Categoria`);

--
-- Índices para tabela `tbl_cliente`
--
ALTER TABLE `tbl_cliente`
  ADD PRIMARY KEY (`id_Cliente`),
  ADD UNIQUE KEY `nif_bi` (`nif_bi`),
  ADD KEY `id_Contacto` (`id_Contacto`),
  ADD KEY `id_Endereco` (`id_Endereco`),
  ADD KEY `id_Tipo_Cliente` (`id_Tipo_Cliente`);

--
-- Índices para tabela `tbl_compra`
--
ALTER TABLE `tbl_compra`
  ADD PRIMARY KEY (`id_Compra`),
  ADD KEY `id_Gestor` (`id_Gestor`),
  ADD KEY `id_Fornecedor` (`id_Fornecedor`),
  ADD KEY `id_Forma_Pagamento` (`id_Forma_Pagamento`);

--
-- Índices para tabela `tbl_contacto`
--
ALTER TABLE `tbl_contacto`
  ADD PRIMARY KEY (`id_Contacto`);

--
-- Índices para tabela `tbl_endereco`
--
ALTER TABLE `tbl_endereco`
  ADD PRIMARY KEY (`id_Endereco`);

--
-- Índices para tabela `tbl_forma_pagamento`
--
ALTER TABLE `tbl_forma_pagamento`
  ADD PRIMARY KEY (`id_Forma_Pagamento`);

--
-- Índices para tabela `tbl_fornecedor`
--
ALTER TABLE `tbl_fornecedor`
  ADD PRIMARY KEY (`id_Fornecedor`),
  ADD UNIQUE KEY `nif_bi` (`nif_bi`),
  ADD KEY `id_Contacto` (`id_Contacto`),
  ADD KEY `id_Endereco` (`id_Endereco`),
  ADD KEY `id_Tipo_Fornecedor` (`id_Tipo_Fornecedor`);

--
-- Índices para tabela `tbl_gestor`
--
ALTER TABLE `tbl_gestor`
  ADD PRIMARY KEY (`id_Gestor`),
  ADD KEY `id_Pessoa` (`id_Pessoa`);

--
-- Índices para tabela `tbl_itenscompra`
--
ALTER TABLE `tbl_itenscompra`
  ADD PRIMARY KEY (`id_Compra`,`id_Produto`),
  ADD KEY `id_Produto` (`id_Produto`);

--
-- Índices para tabela `tbl_itens_venda`
--
ALTER TABLE `tbl_itens_venda`
  ADD PRIMARY KEY (`id_Venda`,`id_Produto`),
  ADD KEY `id_Produto` (`id_Produto`);

--
-- Índices para tabela `tbl_marca`
--
ALTER TABLE `tbl_marca`
  ADD PRIMARY KEY (`id_Marca`);

--
-- Índices para tabela `tbl_modelo`
--
ALTER TABLE `tbl_modelo`
  ADD PRIMARY KEY (`id_Modelo`);

--
-- Índices para tabela `tbl_pessoa`
--
ALTER TABLE `tbl_pessoa`
  ADD PRIMARY KEY (`id_Pessoa`),
  ADD UNIQUE KEY `bi` (`bi`),
  ADD KEY `id_Contacto` (`id_Contacto`),
  ADD KEY `id_Endereco` (`id_Endereco`);

--
-- Índices para tabela `tbl_produto`
--
ALTER TABLE `tbl_produto`
  ADD PRIMARY KEY (`id_Produto`),
  ADD KEY `id_Categoria` (`id_Categoria`),
  ADD KEY `id_Marca` (`id_Marca`),
  ADD KEY `id_Modelo` (`id_Modelo`),
  ADD KEY `id_Unidade` (`id_Unidade`);

--
-- Índices para tabela `tbl_temp_produto`
--
ALTER TABLE `tbl_temp_produto`
  ADD PRIMARY KEY (`Id_Produto_Temp`,`id_Produto`),
  ADD KEY `fk_produto_temp` (`id_Produto`);

--
-- Índices para tabela `tbl_tipo_cliente_fornecedor`
--
ALTER TABLE `tbl_tipo_cliente_fornecedor`
  ADD PRIMARY KEY (`id_Tipo_Cliente_Fornecedor`);

--
-- Índices para tabela `tbl_unidade`
--
ALTER TABLE `tbl_unidade`
  ADD PRIMARY KEY (`id_Unidade`);

--
-- Índices para tabela `tbl_usuario`
--
ALTER TABLE `tbl_usuario`
  ADD PRIMARY KEY (`id_Usuario`);

--
-- Índices para tabela `tbl_usuario_gestor`
--
ALTER TABLE `tbl_usuario_gestor`
  ADD PRIMARY KEY (`id_Gestor`,`id_Usuario`),
  ADD KEY `id_Usuario` (`id_Usuario`);

--
-- Índices para tabela `tbl_usuario_vendedor`
--
ALTER TABLE `tbl_usuario_vendedor`
  ADD PRIMARY KEY (`id_Vendedor`,`id_Usuario`),
  ADD KEY `id_Usuario` (`id_Usuario`);

--
-- Índices para tabela `tbl_venda`
--
ALTER TABLE `tbl_venda`
  ADD PRIMARY KEY (`id_Venda`),
  ADD KEY `id_Vendedor` (`id_Vendedor`),
  ADD KEY `id_Cliente` (`id_Cliente`),
  ADD KEY `id_Forma_Pagamento` (`id_Forma_Pagamento`);

--
-- Índices para tabela `tbl_vendedor`
--
ALTER TABLE `tbl_vendedor`
  ADD PRIMARY KEY (`id_Vendedor`),
  ADD KEY `id_Pessoa` (`id_Pessoa`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `tbl_categoria`
--
ALTER TABLE `tbl_categoria`
  MODIFY `id_Categoria` smallint(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `tbl_cliente`
--
ALTER TABLE `tbl_cliente`
  MODIFY `id_Cliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT de tabela `tbl_compra`
--
ALTER TABLE `tbl_compra`
  MODIFY `id_Compra` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tbl_contacto`
--
ALTER TABLE `tbl_contacto`
  MODIFY `id_Contacto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de tabela `tbl_endereco`
--
ALTER TABLE `tbl_endereco`
  MODIFY `id_Endereco` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de tabela `tbl_forma_pagamento`
--
ALTER TABLE `tbl_forma_pagamento`
  MODIFY `id_Forma_Pagamento` smallint(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `tbl_fornecedor`
--
ALTER TABLE `tbl_fornecedor`
  MODIFY `id_Fornecedor` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tbl_gestor`
--
ALTER TABLE `tbl_gestor`
  MODIFY `id_Gestor` smallint(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `tbl_marca`
--
ALTER TABLE `tbl_marca`
  MODIFY `id_Marca` smallint(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de tabela `tbl_modelo`
--
ALTER TABLE `tbl_modelo`
  MODIFY `id_Modelo` smallint(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `tbl_pessoa`
--
ALTER TABLE `tbl_pessoa`
  MODIFY `id_Pessoa` smallint(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de tabela `tbl_produto`
--
ALTER TABLE `tbl_produto`
  MODIFY `id_Produto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de tabela `tbl_temp_produto`
--
ALTER TABLE `tbl_temp_produto`
  MODIFY `Id_Produto_Temp` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de tabela `tbl_tipo_cliente_fornecedor`
--
ALTER TABLE `tbl_tipo_cliente_fornecedor`
  MODIFY `id_Tipo_Cliente_Fornecedor` tinyint(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `tbl_unidade`
--
ALTER TABLE `tbl_unidade`
  MODIFY `id_Unidade` smallint(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `tbl_usuario`
--
ALTER TABLE `tbl_usuario`
  MODIFY `id_Usuario` smallint(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `tbl_venda`
--
ALTER TABLE `tbl_venda`
  MODIFY `id_Venda` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT de tabela `tbl_vendedor`
--
ALTER TABLE `tbl_vendedor`
  MODIFY `id_Vendedor` smallint(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `tbl_cliente`
--
ALTER TABLE `tbl_cliente`
  ADD CONSTRAINT `tbl_cliente_ibfk_1` FOREIGN KEY (`id_Contacto`) REFERENCES `tbl_contacto` (`id_Contacto`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_cliente_ibfk_2` FOREIGN KEY (`id_Endereco`) REFERENCES `tbl_endereco` (`id_Endereco`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_cliente_ibfk_3` FOREIGN KEY (`id_Tipo_Cliente`) REFERENCES `tbl_tipo_cliente_fornecedor` (`id_Tipo_Cliente_Fornecedor`) ON UPDATE CASCADE;

--
-- Limitadores para a tabela `tbl_compra`
--
ALTER TABLE `tbl_compra`
  ADD CONSTRAINT `tbl_compra_ibfk_1` FOREIGN KEY (`id_Gestor`) REFERENCES `tbl_gestor` (`id_Gestor`) ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_compra_ibfk_2` FOREIGN KEY (`id_Fornecedor`) REFERENCES `tbl_fornecedor` (`id_Fornecedor`) ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_compra_ibfk_3` FOREIGN KEY (`id_Forma_Pagamento`) REFERENCES `tbl_forma_pagamento` (`id_Forma_Pagamento`) ON UPDATE CASCADE;

--
-- Limitadores para a tabela `tbl_fornecedor`
--
ALTER TABLE `tbl_fornecedor`
  ADD CONSTRAINT `tbl_fornecedor_ibfk_1` FOREIGN KEY (`id_Contacto`) REFERENCES `tbl_contacto` (`id_Contacto`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_fornecedor_ibfk_2` FOREIGN KEY (`id_Endereco`) REFERENCES `tbl_endereco` (`id_Endereco`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_fornecedor_ibfk_3` FOREIGN KEY (`id_Tipo_Fornecedor`) REFERENCES `tbl_tipo_cliente_fornecedor` (`id_Tipo_Cliente_Fornecedor`) ON UPDATE CASCADE;

--
-- Limitadores para a tabela `tbl_gestor`
--
ALTER TABLE `tbl_gestor`
  ADD CONSTRAINT `tbl_gestor_ibfk_1` FOREIGN KEY (`id_Pessoa`) REFERENCES `tbl_pessoa` (`id_Pessoa`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limitadores para a tabela `tbl_itenscompra`
--
ALTER TABLE `tbl_itenscompra`
  ADD CONSTRAINT `tbl_itenscompra_ibfk_1` FOREIGN KEY (`id_Compra`) REFERENCES `tbl_compra` (`id_Compra`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_itenscompra_ibfk_2` FOREIGN KEY (`id_Produto`) REFERENCES `tbl_produto` (`id_Produto`) ON UPDATE CASCADE;

--
-- Limitadores para a tabela `tbl_itens_venda`
--
ALTER TABLE `tbl_itens_venda`
  ADD CONSTRAINT `tbl_itens_venda_ibfk_1` FOREIGN KEY (`id_Venda`) REFERENCES `tbl_venda` (`id_Venda`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_itens_venda_ibfk_2` FOREIGN KEY (`id_Produto`) REFERENCES `tbl_produto` (`id_Produto`) ON UPDATE CASCADE;

--
-- Limitadores para a tabela `tbl_pessoa`
--
ALTER TABLE `tbl_pessoa`
  ADD CONSTRAINT `tbl_pessoa_ibfk_1` FOREIGN KEY (`id_Contacto`) REFERENCES `tbl_contacto` (`id_Contacto`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_pessoa_ibfk_2` FOREIGN KEY (`id_Endereco`) REFERENCES `tbl_endereco` (`id_Endereco`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Limitadores para a tabela `tbl_produto`
--
ALTER TABLE `tbl_produto`
  ADD CONSTRAINT `tbl_produto_ibfk_1` FOREIGN KEY (`id_Categoria`) REFERENCES `tbl_categoria` (`id_Categoria`) ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_produto_ibfk_2` FOREIGN KEY (`id_Marca`) REFERENCES `tbl_marca` (`id_Marca`) ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_produto_ibfk_3` FOREIGN KEY (`id_Modelo`) REFERENCES `tbl_modelo` (`id_Modelo`) ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_produto_ibfk_4` FOREIGN KEY (`id_Unidade`) REFERENCES `tbl_unidade` (`id_Unidade`) ON UPDATE CASCADE;

--
-- Limitadores para a tabela `tbl_temp_produto`
--
ALTER TABLE `tbl_temp_produto`
  ADD CONSTRAINT `fk_produto_temp` FOREIGN KEY (`id_Produto`) REFERENCES `tbl_produto` (`id_Produto`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limitadores para a tabela `tbl_usuario_gestor`
--
ALTER TABLE `tbl_usuario_gestor`
  ADD CONSTRAINT `tbl_usuario_gestor_ibfk_1` FOREIGN KEY (`id_Gestor`) REFERENCES `tbl_gestor` (`id_Gestor`) ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_usuario_gestor_ibfk_2` FOREIGN KEY (`id_Usuario`) REFERENCES `tbl_usuario` (`id_Usuario`) ON UPDATE CASCADE;

--
-- Limitadores para a tabela `tbl_usuario_vendedor`
--
ALTER TABLE `tbl_usuario_vendedor`
  ADD CONSTRAINT `tbl_usuario_vendedor_ibfk_1` FOREIGN KEY (`id_Vendedor`) REFERENCES `tbl_vendedor` (`id_Vendedor`) ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_usuario_vendedor_ibfk_2` FOREIGN KEY (`id_Usuario`) REFERENCES `tbl_usuario` (`id_Usuario`) ON UPDATE CASCADE;

--
-- Limitadores para a tabela `tbl_venda`
--
ALTER TABLE `tbl_venda`
  ADD CONSTRAINT `tbl_venda_ibfk_1` FOREIGN KEY (`id_Vendedor`) REFERENCES `tbl_vendedor` (`id_Vendedor`) ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_venda_ibfk_2` FOREIGN KEY (`id_Cliente`) REFERENCES `tbl_cliente` (`id_Cliente`) ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_venda_ibfk_3` FOREIGN KEY (`id_Forma_Pagamento`) REFERENCES `tbl_forma_pagamento` (`id_Forma_Pagamento`) ON UPDATE CASCADE;

--
-- Limitadores para a tabela `tbl_vendedor`
--
ALTER TABLE `tbl_vendedor`
  ADD CONSTRAINT `tbl_vendedor_ibfk_1` FOREIGN KEY (`id_Pessoa`) REFERENCES `tbl_pessoa` (`id_Pessoa`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
