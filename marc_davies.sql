-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 17, 2019 at 03:56 PM
-- Server version: 5.7.24
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `marc_davies`
--
CREATE DATABASE IF NOT EXISTS `marc_davies` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `marc_davies`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `phone_number` varchar(255) NOT NULL,
  `email_address` varchar(255) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `first_name`, `last_name`, `phone_number`, `email_address`, `stylist_id`) VALUES
(1, 'Marc', 'Davies', '3232866556', 'marcdaviesriot@gmail.com', 1),
(2, 'Mimi', 'Davies', '3232746995', 'mimimdavies@gmail.com', 3),
(3, 'Chloe', 'Davies', '3232866886', 'chloedavies@gmail.com', 2);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`id`, `name`, `description`) VALUES
(1, 'Ally', 'Ally wants to create hair as dimensional as the lives of her clients, and is a visual artist, using hair as her chosen art form and medium. Ally thrives in a problem solving approach to a hair service or corrective color. She enjoys creating movement and texture for medium to long hair lengths, and cultivating functional hairstyles to suit the lifestyles of her clients.       '),
(2, 'Rachel', 'Whether it’s a breezy blonde balayage or perfectly blended extensions, Rachel loves it all. Rachel is motivated to emphasize your natural beauty and have you leaving the salon refreshed and confident, always keeping the integrity of your hair at the forefront of her work. She enjoys working with all shades of blonde, and fine textured hair.       '),
(3, 'Noelle', 'Noelle uses her passion for, knowledge of retro styling and hunger for learning cutting edge technique to fuel her art form. She wants to get to know you, your lifestyle and ultimate hair goals, in order to find the look and feel you’ve been searching for, and that is uniquely you.       ');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
