USE firstdatabase123;
-- CREATE TABLE jobs
-- (
--   id INT AUTO_INCREMENT NOT NULL,
--   location VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,

--   PRIMARY KEY(id)
-- )
-- CREATE TABLE contractors
-- (
--   id INT AUTO_INCREMENT NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   industry VARCHAR(255) NOT NULL,

--   PRIMARY KEY(id)
-- )

-- CREATE TABLE contractorjobs
-- (
--   id INT AUTO_INCREMENT,
--   contractorId INT NOT NULL,
--   jobId INT NOT NULL,

--   PRIMARY KEY(id),

--   FOREIGN KEY (jobId)
--     REFERENCES jobs(id)
--     ON DELETE CASCADE,

--   FOREIGN KEY (contractorId)
--     REFERENCES contractors(id)
--     ON DELETE CASCADE
-- )