-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 08-05-2023 a las 14:32:05
-- Versión del servidor: 10.4.27-MariaDB
-- Versión de PHP: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `aev7`
--
CREATE DATABASE IF NOT EXISTS `aev7` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `aev7`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleados`
--

DROP TABLE IF EXISTS `empleados`;
CREATE TABLE IF NOT EXISTS `empleados` (
  `nif` varchar(9) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) NOT NULL,
  `administrador` tinyint(1) NOT NULL,
  `clave` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`nif`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `empleados`
--

INSERT INTO `empleados` (`nif`, `nombre`, `apellido`, `administrador`, `clave`) VALUES
('11111111H', 'JUAN', 'MARQUES', 1, '1dam');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `fichajes`
--

DROP TABLE IF EXISTS `fichajes`;
CREATE TABLE IF NOT EXISTS `fichajes` (
  `Empleado_nif` varchar(9) NOT NULL,
  `dia` date NOT NULL,
  `horaEntrada` time DEFAULT NULL,
  `horaSalida` time DEFAULT NULL,
  `finalizado` tinyint(1) DEFAULT 0,
  `tiempoTotal` time DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `fichajes`
--

INSERT INTO `fichajes` (`Empleado_nif`, `dia`, `horaEntrada`, `horaSalida`, `finalizado`, `tiempoTotal`) VALUES
('11111111H', '2023-04-29', '20:54:43', '21:54:48', 1, '01:00:05'),
('26580612H', '2023-04-30', '22:23:35', '22:23:43', 1, '00:00:08'),
('26580612H', '2023-05-07', '16:04:03', '21:24:39', 1, '05:20:36'),
('11111111H', '2023-05-07', '21:39:09', '23:59:59', 1, '02:20:50');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
