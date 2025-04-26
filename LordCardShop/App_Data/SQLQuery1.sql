CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserName VARCHAR(255) NOT NULL,
    UserEmail VARCHAR(50) NOT NULL,
    UserPassword VARCHAR(50) NOT NULL,
    UserGender VARCHAR(100) NOT NULL,
    UserDOB DATE NOT NULL,
    UserRole VARCHAR(100) NOT NULL
);

CREATE TABLE Cards (
    CardID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CardName VARCHAR(100) NOT NULL,
    CardPrice FLOAT(10) NOT NULL,
    CardDesc VARCHAR(255) NOT NULL,
    CardType VARCHAR(100) NOT NULL,
    IsFoil BINARY(1) NOT NULL
);

CREATE TABLE TransactionHeader (
    TransactionID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TransactionDate DATE NOT NULL,
    CustomerID INT NOT NULL,
    [Status] VARCHAR(100) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Users(UserID)
);

CREATE TABLE TransactionDetail (
    TransactionID INT NOT NULL,
    CardID INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (TransactionID) REFERENCES TransactionHeader(TransactionID),
    FOREIGN KEY (CardID) REFERENCES Cards(CardID)
);

CREATE TABLE Carts (
    CartID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CardID INT NOT NULL,
    UserID INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (CardID) REFERENCES Cards(CardID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
