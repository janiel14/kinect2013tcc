CREATE SCHEMA IF NOT EXISTS `kinectdb` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `kinectdb` ;

-- -----------------------------------------------------
-- Table `kinectdb`.`clinica`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`clinica` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `cnpj` VARCHAR(20) NOT NULL ,
  `razao_social` VARCHAR(80) NOT NULL ,
  `nome_fantasia` VARCHAR(80) NULL ,
  `logradouro` VARCHAR(80) NOT NULL ,
  `numero` INT NOT NULL ,
  `complemento` VARCHAR(45) NULL ,
  `bairro` VARCHAR(45) NOT NULL ,
  `cep` VARCHAR(20) NOT NULL ,
  `cidade` VARCHAR(45) NOT NULL ,
  `uf` VARCHAR(45) NOT NULL ,
  `telefone` VARCHAR(20) NULL ,
  `celular` VARCHAR(20) NULL ,
  `email` VARCHAR(80) NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`paciente`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`paciente` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `clinica_id` INT NOT NULL ,
  `nome` VARCHAR(80) NOT NULL ,
  `cpf` VARCHAR(20) NOT NULL ,
  `rg` VARCHAR(20) NOT NULL ,
  `sexo` VARCHAR(1) NOT NULL ,
  `data_de_nasc` DATE NOT NULL ,
  `estado_civil` VARCHAR(20) NOT NULL ,
  `profissao` VARCHAR(45) NOT NULL ,
  `logradouro` VARCHAR(80) NOT NULL ,
  `numero` INT NOT NULL ,
  `complemento` VARCHAR(45) NULL ,
  `bairro` VARCHAR(45) NOT NULL ,
  `cep` VARCHAR(20) NOT NULL ,
  `cidade` VARCHAR(45) NOT NULL ,
  `uf` VARCHAR(2) NOT NULL ,
  `telefone` VARCHAR(20) NULL ,
  `celular` VARCHAR(20) NULL ,
  `email` VARCHAR(80) NULL ,
  `observacao` TEXT NULL ,
  `data_do_cadastro` DATE NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_paciente_clinica1_idx` (`clinica_id` ASC) ,
  CONSTRAINT `fk_paciente_clinica1`
    FOREIGN KEY (`clinica_id` )
    REFERENCES `kinectdb`.`clinica` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`fisioterapeuta`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`fisioterapeuta` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `clinica_id` INT NOT NULL ,
  `nome` VARCHAR(80) NOT NULL ,
  `cpf` VARCHAR(20) NOT NULL ,
  `rg` VARCHAR(20) NOT NULL ,
  `crefito` VARCHAR(20) NOT NULL ,
  `especializacao` VARCHAR(80) NULL ,
  `sexo` VARCHAR(1) NOT NULL ,
  `data_de_nasc` DATE NOT NULL ,
  `estado_civil` VARCHAR(20) NOT NULL ,
  `logradouro` VARCHAR(80) NOT NULL ,
  `numero` INT NOT NULL ,
  `complemento` VARCHAR(45) NULL ,
  `bairro` VARCHAR(45) NOT NULL ,
  `cep` VARCHAR(20) NOT NULL ,
  `cidade` VARCHAR(45) NOT NULL ,
  `uf` VARCHAR(2) NOT NULL ,
  `telefone` VARCHAR(20) NULL ,
  `celular` VARCHAR(20) NULL ,
  `email` VARCHAR(80) NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_fisioterapeuta_clinica_idx` (`clinica_id` ASC) ,
  CONSTRAINT `fk_fisioterapeuta_clinica`
    FOREIGN KEY (`clinica_id` )
    REFERENCES `kinectdb`.`clinica` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`ficha_de_avaliacao`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`ficha_de_avaliacao` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `paciente_id` INT NOT NULL ,
  `data_da_avaliacao` DATE NOT NULL ,
  `data_prox_avaliacao` DATE NULL ,
  `dias_de_aula` VARCHAR(45) NULL ,
  `data_de_vencimento` DATE NOT NULL ,
  `diagnostico` TEXT NOT NULL ,
  `objetivo` TEXT NOT NULL ,
  `conduta` TEXT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `fk_ficha_de_avaliacao_paciente1_idx` (`paciente_id` ASC) ,
  CONSTRAINT `fk_ficha_de_avaliacao_paciente1`
    FOREIGN KEY (`paciente_id` )
    REFERENCES `kinectdb`.`paciente` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`sessao`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`sessao` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `clinica_id` INT NOT NULL ,
  `fisioterapeuta_id` INT NOT NULL ,
  `paciente_id` INT NOT NULL ,
  `situacao` VARCHAR(20) NOT NULL ,
  `data` DATE NOT NULL ,
  `hora` TIME NOT NULL ,
  `observacao` TEXT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `sessao_fisioterapeuta_id_idx` (`fisioterapeuta_id` ASC) ,
  INDEX `sessao_paciente_id_idx` (`paciente_id` ASC) ,
  INDEX `sessao_clinica_idx` (`clinica_id` ASC) ,
  CONSTRAINT `sessao_fisioterapeuta_id`
    FOREIGN KEY (`fisioterapeuta_id` )
    REFERENCES `kinectdb`.`fisioterapeuta` (`id` )
    ON DELETE RESTRICT
    ON UPDATE NO ACTION,
  CONSTRAINT `sessao_paciente_id`
    FOREIGN KEY (`paciente_id` )
    REFERENCES `kinectdb`.`paciente` (`id` )
    ON DELETE RESTRICT
    ON UPDATE NO ACTION,
  CONSTRAINT `sessao_clinica_id`
    FOREIGN KEY (`clinica_id` )
    REFERENCES `kinectdb`.`clinica` (`id` )
    ON DELETE RESTRICT
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`hand_right`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`hand_right` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `hand_right_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`wrist_right`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`wrist_right` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `wrist_right_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`elbow_right`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`elbow_right` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `elbow_right_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`shoulder_right`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`shoulder_right` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `shoulder_right_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`head`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`head` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `head_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`shoulder_center`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`shoulder_center` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `shoulder_center_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`shoulder_left`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`shoulder_left` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `shoulder_left_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`elbow_left`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`elbow_left` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `elbow_left_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`wrist_left`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`wrist_left` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `wrist_left_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`hand_left`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`hand_left` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `hand_left_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`spine`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`spine` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `spine_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`hip_center`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`hip_center` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `hip_center_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`hip_right`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`hip_right` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `hip_right_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`knee_right`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`knee_right` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `knee_right_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`ankle_right`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`ankle_right` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `ankle_right_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`foot_right`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`foot_right` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `foot_right_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`foot_left`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`foot_left` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `foot_left_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`ankle_left`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`ankle_left` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `ankle_left_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`knee_left`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`knee_left` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `knee_left_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`hip_left`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`hip_left` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NOT NULL ,
  `y` DOUBLE NOT NULL ,
  `z` DOUBLE NOT NULL ,
  `angulo` INT NOT NULL ,
  `tempo` INT(20) NOT NULL ,
  `velocidade` INT NOT NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `hand_right_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `hip_left_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `kinectdb`.`body`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `kinectdb`.`body` (
  `id` INT NOT NULL AUTO_INCREMENT ,
  `sessao_id` INT NOT NULL ,
  `x` DOUBLE NULL ,
  `y` DOUBLE NULL ,
  `z` DOUBLE NULL ,
  `tempo` INT(20) NULL ,
  PRIMARY KEY (`id`) ,
  INDEX `body_sessao_id_idx` (`sessao_id` ASC) ,
  CONSTRAINT `body_sessao_id`
    FOREIGN KEY (`sessao_id` )
    REFERENCES `kinectdb`.`sessao` (`id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB;