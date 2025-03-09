Create Empty Parent at Center
📌 Overview
This Unity Editor tool allows you to create an empty parent at the center of selected objects, instead of using their pivot points like Unity’s default "Create Empty Parent" does. This ensures better grouping and alignment when working with multiple objects.

🚀 Why Use This?
🔹 Default Unity behavior creates the parent using the pivot points of selected objects, which may not always be ideal.
🔹 This tool calculates the true center based on the bounding box of all selected objects instead.
🔹 Keeps object hierarchy intact while allowing precise organization.

📥 Installation
1️⃣ Copy CreateEmptyParentAtCenter.cs into your Editor folder (Assets/Editor/).
2️⃣ Open Unity and go to GameObject → Create Empty Parent at Center in the menu bar.

🛠️ How It Works
1️⃣ Select multiple objects in the Hierarchy.
2️⃣ Click GameObject → Create Empty Parent at Center or use a custom shortcut (if assigned).
3️⃣ A new empty parent is created at the calculated center of the selected objects.
4️⃣ The selected objects are reparented under this new empty GameObject.
5️⃣ The tool automatically highlights and renames the new parent in the Hierarchy.

📌 Features
✔️ Centers the new parent based on object bounds, not pivots.
✔️ Maintains hierarchy & keeps relative positions intact.
✔️ Automatically selects the new parent for quick renaming.
✔️ Works with all types of objects, including meshes & non-mesh objects.

🎯 Usage Example
Imagine selecting multiple props, environment assets, or UI elements. Instead of manually adjusting a new empty parent, just:
✅ Select objects → Click "Create Empty Parent at Center" → Done!

Your new parent is now at the true geometric center of the selected objects, making it easier to manipulate and align them.

📜 License
This tool is free & open-source under the MIT License.
👉 Feel free to use, modify, and contribute!

🤝 Contributing
🔹 Want to improve this tool? Open an Issue or submit a Pull Request here.

🚀 Happy Unity development! 🎮


UnityTools

A collection of useful scripts and utilities to enhance Unity game development. This repository is designed to provide various tools that simplify workflows, improve efficiency, and solve common development challenges.

📂 Repository Structure
Each tool is categorized into its own branch, allowing developers to pick and choose what they need without downloading the entire repository.

🔀 Available Branches
lod-merger - A script to merge multiple LODGroups into a single optimized LOD structure.
(More branches/tools will be added over time.)
You can check out a specific tool using:

bash
Copy
Edit
git checkout <branch-name>
🔧 How to Use
Clone the Repository
bash
Copy
Edit
git clone https://github.com/Shripad-S-Agashe/UnityTools.git
Switch to the Desired Branch
bash
Copy
Edit
git checkout lod-merger
Import the Required Scripts
Copy the necessary files into your Unity project under Assets/Scripts/.
If there are editor scripts, place them in an Editor/ folder.
🛠 Tools List
Below are some of the planned and existing tools:

Tool	Branch Name	Description
LOD Group Merger	lod-merger	Merges multiple LODGroups into a single optimized LOD structure.
(Coming Soon)	...	More tools to be added soon!
📜 License
This project is licensed under the MIT License. See the LICENSE file for details.

🤝 Contributing
Contributions are welcome! To add a new tool:

Create a new branch for your tool.
Add your script(s) with proper documentation.
Submit a pull request with details about the tool.
📢 Contact & Support
If you have suggestions, issues, or feature requests, open an issue on GitHub!
