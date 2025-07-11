CREATE TABLE records (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    username1 VARCHAR(128),
    username2 VARCHAR(128),
    map_id INT NOT NULL,
    time_record TIMESTAMP,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP()
)