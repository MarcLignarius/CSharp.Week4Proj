-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 21, 2019 at 11:03 AM
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
(2, 'Mimi', 'Davies', '3232746995', 'mimimdavies@gmail.com', 3),
(3, 'Chloe', 'Davies', '3232866886', 'chloedavies@gmail.com', 2),
(6, 'Audrey', 'Couyras', '0677700809', 'courasaudrey@gmail.com', 4);

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`id`, `name`, `description`) VALUES
(5, 'Bridal', 'Your wedding is truly one of the most remembered days of your life and Neroli is committed to making your day as special as you had imagined it to be. We provide our brides with a Bridal Concierge who will assist you throughout the planning process, allowing for an effortless experience. '),
(6, 'Make-up', 'We offer makeup services that enhance natural beauty with Aveda makeup products created from plant derived minerals. Our highly-skilled makeup artists will bring out your best while you enjoy the natural serenity of our elegant salons.\r\n\r\nThrough our makeup services, you will discover that Aveda makeup products care for your skin, enhance your natural beauty, and are talc, mineral oil and paraben free. Aveda makeup products are infused with only the purest ingredients, such as essential oils, tourmaline, mica and lavender.'),
(7, 'Microblading', 'Enhance your brows with this manual permanent makeup treatment that uses a hair stroke technique to resemble the look of natural brows.\r\n\r\nPigment is manually implanted directly under the skin by using a small uniquely designed blade.\r\n\r\nRegardless of the amount of hair present the results are a natural, flawless, fuller looking brow. The pigments used in this method have been formulated to match your original eyebrow color, and if the eyebrows are still present, blend perfectly into them.'),
(8, 'Skin Care', 'We offer high performance customized facials and body treatments to provide you with visible results. Each spa service includes a foot soak, consultation, cleanse and hydration of the face and décolleté area.');

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
(2, 'Rachel', 'Whether it’s a breezy blonde balayage or perfectly blended extensions, Rachel loves it all. Rachel is motivated to emphasize your natural beauty and have you leaving the salon refreshed and confident, always keeping the integrity of your hair at the forefront of her work. She enjoys working with all shades of blonde, and fine textured hair.       '),
(3, 'Noelle', 'Noelle uses her passion for, knowledge of retro styling and hunger for learning cutting edge technique to fuel her art form. She wants to get to know you, your lifestyle and ultimate hair goals, in order to find the look and feel you’ve been searching for, and that is uniquely you.       '),
(4, 'Amber', 'Amber has been honing her hair artistry for 10 years. She received her training from Paul Mitchell School and has furthered her education over the years through Aveda, Goldwell, Bumble and Bumble and Oribe, and had her work featured in InStyle magazine in 2012. Amber enjoys working with your natural hair texture to emphasize your best features. More than anything, Amber wants to give you hair that is easy to maintain and makes you feel beautiful everyday; she gives her clients all the necessary tools and technique to achieve the perfect salon look in their own home. She loves working with natural balayage, beachy waves, long cuts, blondes of all shades, and thick hair.');

-- --------------------------------------------------------

--
-- Table structure for table `stylists_specialties`
--

CREATE TABLE `stylists_specialties` (
  `id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists_specialties`
--

INSERT INTO `stylists_specialties` (`id`, `stylist_id`, `specialty_id`) VALUES
(1, 2, 0),
(2, 2, 1),
(3, 2, 3),
(4, 3, 3),
(5, 4, 3),
(6, 2, 5),
(7, 3, 6),
(8, 4, 7),
(9, 2, 8),
(10, 3, 8),
(11, 4, 8);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists_specialties`
--
ALTER TABLE `stylists_specialties`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `stylists_specialties`
--
ALTER TABLE `stylists_specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
