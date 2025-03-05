# Simple Text Editor - README

## Description
This is a simple text editor built using Telerik's WinForms controls and C#. The application allows users to create, edit, and save text files. It provides essential features like text formatting (bold and italic), file handling (open, save, and clear), and text manipulation (cut, copy, and paste). Additionally, it displays the word count of the current text.

## Features
- **File Operations:**
  - **New**: Clears the editor's content.
  - **Open**: Opens an existing `.txt` file and loads its content into the editor.
  - **Save**: Saves the editor content to a `.txt` file.
  - **Exit**: Prompts the user with a confirmation to exit without saving changes.
  
- **Text Editing:**
  - **Cut, Copy, Paste**: Basic text manipulation features to cut, copy, and paste text.
  - **Word Count**: Displays the current word count in the editor.
  
- **Text Formatting:**
  - **Bold**: Toggles bold formatting for selected text.
  - **Italic**: Toggles italic formatting for selected text.

## Requirements
- **Telerik UI for WinForms**: This application requires Telerik's UI for WinForms to work properly. Ensure you have Telerik controls referenced in your project.
- **.NET Framework**: The application uses the .NET Framework for Windows Forms.
- **C# Environment**: A C# development environment (such as Visual Studio) to run the application.

## Usage
1. **Launch the Application**:
   - When you start the application, the editor window appears with a blank document.

2. **Create a New Document**:
   - To create a new document, click on the "New" option in the menu to clear the editor.

3. **Open a File**:
   - Click on the "Open" option from the menu and select a `.txt` file to load into the editor.

4. **Save the Document**:
   - To save your work, click the "Save" option in the menu and select the location to save the file.

5. **Text Editing**:
   - **Cut**: Select text and click "Cut" from the menu to remove it.
   - **Copy**: Select text and click "Copy" to copy the content to the clipboard.
   - **Paste**: Click "Paste" to insert the copied or cut text at the cursor position.

6. **Text Formatting**:
   - Highlight the text you want to format, then click the **Bold** or **Italic** buttons to apply formatting.

7. **Word Count**:
   - The word count is displayed at the bottom of the window and updates as you type.

8. **Exit**:
   - If you attempt to close the application without saving, a confirmation message will appear asking whether you want to exit without saving.

## Code Breakdown
### File Operations
- **Clear Text (New)**: 
  ```csharp
  private void radMenuItem2_Click_1(object sender, EventArgs e)
  {
      radRichTextEditor1.Text = "";  // Clears the editor's text.
  }
  ```

- **Open File**: 
  ```csharp
  private void radMenuItem3_Click(object sender, EventArgs e)
  {
      using (OpenFileDialog openFileDialog = new OpenFileDialog())
      {
          openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*) | *.* ";
          if (openFileDialog.ShowDialog() == DialogResult.OK)
          {
              string filepath = openFileDialog.FileName;
              radRichTextEditor1.Text = File.ReadAllText(filepath);  // Loads the selected file into the editor.
          }
      }
  }
  ```

- **Save File**: 
  ```csharp
  private void radMenuItem4_Click(object sender, EventArgs e)
  {
      using (SaveFileDialog saveFileDialog = new SaveFileDialog())
      {
          saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*) | *.* ";
          if (saveFileDialog.ShowDialog() == DialogResult.OK)
          {
              string filepath = saveFileDialog.FileName;
              File.WriteAllText(filepath, radRichTextEditor1.Text);  // Saves the editor content to the selected file.
          }
      }
  }
  ```

### Text Formatting
- **Bold Formatting**:
  ```csharp
  private void radButton1_Click(object sender, EventArgs e)
  {
      radRichTextEditor1.Commands.ToggleBoldCommand.Execute(null);  // Toggles bold formatting for selected text.
  }
  ```

- **Italic Formatting**:
  ```csharp
  private void radButton2_Click(object sender, EventArgs e)
  {
      radRichTextEditor1.Commands.ToggleItalicCommand.Execute(null);  // Toggles italic formatting for selected text.
  }
  ```

### Word Count
- **Word Count**:
  ```csharp
  private void radLabelElement1_Click(object sender, EventArgs e)
  {
      int wordCount = radRichTextEditor1.Text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
      radLabelElement1.Text = $"Word Count: {wordCount}";
  }
  ```

## Example Usage
1. Open the editor and type some text.
2. Click **Bold** to apply bold formatting to the selected text.
3. Save the file to your desired location.
4. Close the application. If you haven't saved the file, a prompt will ask if you're sure about exiting without saving.

## Author
Cezar Pedroso
