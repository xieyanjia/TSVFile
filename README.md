# TSV 單字檔案讀取系統

## 一、專案簡介

本專案是一個使用 C# Windows Forms 製作的 TSV 單字檔案讀取系統。

程式可以讓使用者開啟 `.tsv` 或 `.txt` 格式的單字資料檔，並將檔案內容顯示在 ListView 表格中。每一筆資料包含單字、音標、音檔路徑與中文解釋，方便使用者瀏覽與查詢單字資料。

本系統除了基本的檔案讀取與顯示功能外，也新增了搜尋功能。使用者可以輸入關鍵字，搜尋單字、音標、音檔路徑或解釋內容，快速找出符合條件的資料。

---

## 二、系統功能

### 1. 開啟 TSV / TXT 檔案

使用者可以透過選單開啟 `.tsv` 或 `.txt` 檔案。

程式會讀取檔案中的每一行資料，並將內容載入到單字清單中，再顯示於 ListView 表格。

### 2. 顯示單字資料

成功載入檔案後，系統會將單字資料顯示在畫面上。

ListView 顯示的欄位包含：

- 單字
- 音標
- 音檔路徑
- 中文解釋

### 3. 搜尋功能

使用者可以在搜尋欄位輸入關鍵字，並按下「搜尋」按鈕。

系統會搜尋以下內容：

- 單字
- 音標
- 音檔路徑
- 中文解釋

只要資料中包含輸入的關鍵字，就會顯示在 ListView 中。

### 4. 顯示全部資料

搜尋後，ListView 只會顯示符合條件的資料。

如果使用者想取消搜尋結果，可以按下「顯示全部」按鈕，系統會清空搜尋欄位，並重新顯示所有已載入的單字資料。

### 5. 狀態列訊息

程式下方的狀態列會顯示目前操作狀態，例如：

```text
100 單字已成功載入
搜尋完成，共找到 8 筆資料
已顯示全部，共 100 筆資料
```
<img width="1300" height="472" alt="image" src="https://github.com/user-attachments/assets/539e2de0-ad23-4ad7-8094-04b9baa7c764" />

<img width="1304" height="471" alt="image" src="https://github.com/user-attachments/assets/1c04157d-5e3c-49b9-890a-247c68a133ad" />

<img width="1305" height="472" alt="image" src="https://github.com/user-attachments/assets/e6524613-f20c-409d-bacb-035a048a2644" />

<img width="1302" height="469" alt="image" src="https://github.com/user-attachments/assets/382244ac-b8b3-4ce5-8061-5296b884e665" />


