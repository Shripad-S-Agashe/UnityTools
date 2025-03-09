LOD Group Merger
A Unity tool that merges multiple LODGroups into a single optimized LOD structure, reducing draw calls and improving performance.

[Video Tutorial ](https://youtu.be/6YnIgpd0O2g)

🚀 Features
✅ Merges multiple LODGroups into a single LODGroup.
✅ Combines meshes per LOD level for better optimization.
✅ Handles pivot alignment so merged meshes retain correct positioning.
✅ Option to delete original LODGroups after merging.
✅ Supports saving merged meshes as assets in Unity’s project folder.
✅ Editor integration: Easily merge LODs via a custom editor button.

📂 Repository Structure
This tool is part of the UnityTools repository, with each tool in its own branch.

🔀 Branches
lod-merger → Merges multiple LODGroups into a single optimized structure.
(More tools will be added in other branches.)
Switch to this branch using:

bash
Copy
Edit
git checkout lod-merger
📥 Installation
You can install this tool in two ways:

1️⃣ Using the Unity Package (Recommended)
Download the LODMerger.unitypackage file from this branch.
In Unity, go to Assets → Import Package → Custom Package....
Select LODMerger.unitypackage and click Import.
2️⃣ Manual Installation (Import Scripts)
Download or clone the repository:
bash
Copy
Edit
git clone -b lod-merger https://github.com/Shripad-S-Agashe/UnityTools.git
Copy the following files into your Unity project:
Assets/Scripts/LODGroupMerger.cs (Main script)
Assets/Editor/LODGroupMergerEditor.cs (Editor script)
Ensure the LODGroupMergerEditor.cs file is inside an Editor folder.
🔧 How It Works
1️⃣ Attach the Script
Add the LODGroupMerger component to a GameObject that contains multiple LODGroups.
2️⃣ Open the Inspector
Select the GameObject with the LODGroupMerger script.
You'll see a "Merge LOD Groups" button in the Inspector.
3️⃣ Click the Button
The tool will:
Find all LODGroups under the selected GameObject.
Merge meshes for each LOD level.
Create a new single LODGroup with optimized meshes.
(Optional) Delete original LODGroups if enabled.
📜 Script Breakdown
📝 LODGroupMerger.cs (Main Script)
Finds all LODGroups inside a parent GameObject.
Groups meshes by LOD level and combines them.
Ensures the pivot is correctly centered.
Saves merged meshes as assets for persistent storage.
(Optional) Deletes the original LODGroups.
📝 LODGroupMergerEditor.cs (Editor Script)
Adds a button in the Unity Inspector to trigger the merge.
Provides a folder picker UI to choose where merged meshes are saved.
⚙️ Options & Settings
Option	Description
Delete Original Models	Removes the original LODGroups after merging (default: true).
Save Path	Choose where to save the merged meshes in Unity’s Assets folder.
Mesh Base Name	Set a custom name for the merged mesh assets.
💡 Best Practices
Use only on static objects (since LODs work best with static batching).
Ensure each LOD level has at least one mesh to avoid missing LODs.
If using nested LODGroups, merge them separately.
🔄 Undo & Safety
LODGroupMerger does not support undo. Always save your project before merging.
You can disable "Delete Original Models" if you want to review the merged result first.
🔍 Example Use Case
You have a complex scene with multiple objects, each with its own LODGroup.
Instead of having many draw calls, you can merge them into a single optimized LODGroup.

📜 License
This tool is licensed under the MIT License.
You are free to use, modify, and distribute it with attribution.

🤝 Contributing
Want to improve the LOD Group Merger? Contributions are welcome!

Fork the repository.
Create a new branch:
bash
Copy
Edit
git checkout -b feature-your-improvement
Submit a pull request with a description of your changes.
📢 Contact & Support
Found a bug? Have a suggestion?
👉 Open an Issue.
Want to contribute? Check the Contribution Guide.
