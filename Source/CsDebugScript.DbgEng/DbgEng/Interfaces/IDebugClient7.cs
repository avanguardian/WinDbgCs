using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DbgEng
{
    /// <summary>
    /// Extension of IDebugClient interface.
    /// </summary>
    /// <seealso cref="DbgEng.IDebugClient6" />
    [ComImport, Guid("13586BE3-542E-481E-B1F2-8497BA74F9A9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDebugClient7 : IDebugClient6
    {
#pragma warning disable CS0108 // XXX hides inherited member. This is COM default.

        #region IDebugClient
        /// <summary>
        /// The AttachKernel methods connect the debugger engine to a kernel target.
        /// </summary>
        /// <param name="Flags">Specifies the flags that control how the debugger attaches to the kernel target.</param>
        /// <param name="ConnectOptions">Specifies the connection settings for communicating with the computer running the kernel target.</param>
        void AttachKernel(
            [In] DebugAttachKernel Flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string ConnectOptions = null);

        /// <summary>
        /// The GetKernelConnectionOptions method returns the connection options for the current kernel target.
        /// </summary>
        /// <param name="Buffer">Specifies the buffer to receive the connection options.</param>
        /// <param name="BufferSize">Specifies the size in characters of the buffer Buffer.</param>
        /// <param name="OptionsSize">Receives the size in characters of the connection options.</param>
        void GetKernelConnectionOptions(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint OptionsSize);

        /// <summary>
        /// The SetKernelConnectionOptions method updates some of the connection options for a live kernel target.
        /// </summary>
        /// <param name="Options">
        /// Specifies the connection options to update. The possible values are:
        /// <para><c>"resync"</c> Re-synchronize the connection between the debugger engine and the kernel.For more information, see Synchronizing with the Target Computer.</para>
        /// <para><c>"cycle_speed"</c> For kernel connections through a COM port, cycle through the supported baud rates; for other connections, do nothing.</para>
        /// </param>
        void SetKernelConnectionOptions(
            [In, MarshalAs(UnmanagedType.LPStr)] string Options);

        /// <summary>
        /// The StartProcessServer method starts a process server.
        /// </summary>
        /// <param name="Flags">Specifies the class of the targets that will be available through the process server. This must be set to <see cref="DebugClass.UserWindows"/>.</param>
        /// <param name="Options">Specifies the connections options for this process server. These are the same options given to the -t option of the DbgSrv command line.</param>
        /// <param name="Reserved">Set to <see cref="IntPtr.Zero"/>.</param>
        void StartProcessServer(
            [In] DebugClass Flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string Options,
            [In] IntPtr Reserved = default(IntPtr));

        /// <summary>
        /// The ConnectProcessServer methods connect to a process server.
        /// </summary>
        /// <param name="RemoteOptions">Specifies how the debugger engine will connect with the process server. These are the same options passed to the -premote option on the WinDbg and CDB command lines.</param>
        /// <returns>Returns a handle for the process server. This handle is used when creating or attaching to processes by using the process server.</returns>
        ulong ConnectProcessServer(
            [In, MarshalAs(UnmanagedType.LPStr)] string RemoteOptions);

        /// <summary>
        /// The DisconnectProcessServer method disconnects the debugger engine from a process server.
        /// </summary>
        /// <param name="Server">Specifies the server from which to disconnect. This handle must have been previously returned by <see cref="ConnectProcessServer"/>.</param>
        void DisconnectProcessServer(
            [In] ulong Server);

        /// <summary>
        /// The GetRunningProcessSystemIds method returns the process IDs for each running process.
        /// </summary>
        /// <param name="Server">Specifies the process server to query for process IDs. If Server is zero, the engine will return the process IDs of the processes running on the local computer.</param>
        /// <param name="Ids">Receives the process IDs. The size of this array is <paramref name="Count"/>. If <paramref name="Ids"/> is <c>null</c>, this information is not returned.</param>
        /// <param name="Count">Specifies the number of process IDs the array <paramref name="Ids"/> can hold.</param>
        /// <param name="ActualCount">Receives the actual number of process IDs returned in <paramref name="Ids"/>.</param>
        void GetRunningProcessSystemIds(
            [In] ulong Server,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] Ids,
            [In] uint Count,
            [Out] out uint ActualCount);

        /// <summary>
        /// The GetRunningProcessSystemIdByExecutableName method searches for a process with a given executable file name and return its process ID.
        /// </summary>
        /// <param name="Server">Specifies the process server to search for the executable name. If Server is zero, the engine will search for the executable name among the processes running on the local computer.</param>
        /// <param name="ExeName">Specifies the executable file name for which to search.</param>
        /// <param name="Flags">Specifies a bit-set that controls how the executable name is matched.</param>
        /// <returns>Returns the process ID of the first process to match <paramref name="ExeName"/>.</returns>
        uint GetRunningProcessSystemIdByExecutableName(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string ExeName,
            [In] DebugGetProc Flags);

        /// <summary>
        /// The GetRunningProcessDescription method returns a description of the process that includes the executable image name, the service names, the MTS package names, and the command line.
        /// </summary>
        /// <param name="Server">Specifies the process server to query for the process description. If Server is zero, the engine will query information about the local process directly.</param>
        /// <param name="SystemId">Specifies the process ID of the process whose description is desired.</param>
        /// <param name="Flags">Specifies a bit-set containing options that affect the behavior of this method.</param>
        /// <param name="ExeName">Receives the name of the executable file used to start the process. If ExeName is <c>null</c>, this information is not returned.</param>
        /// <param name="ExeNameSize">Specifies the size in characters of the buffer <paramref name="ExeName"/>.</param>
        /// <param name="ActualExeNameSize">Receives the size in characters of the executable file name.</param>
        /// <param name="Description">Receives extra information about the process, including service names, MTS package names, and the command line. If Description is <c>null</c>, this information is not returned.</param>
        /// <param name="DescriptionSize">Specifies the size in characters of the buffer <paramref name="Description"/>.</param>
        /// <param name="ActualDescriptionSize">Receives the size in characters of the extra information.</param>
        void GetRunningProcessDescription(
            [In] ulong Server,
            [In] uint SystemId,
            [In] DebugProcDesc Flags,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder ExeName,
            [In] uint ExeNameSize,
            [Out] out uint ActualExeNameSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Description,
            [In] uint DescriptionSize,
            [Out] out uint ActualDescriptionSize);

        /// <summary>
        /// The AttachProcess method connects the debugger engine to a user-modeprocess.
        /// </summary>
        /// <param name="Server">Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to a local process without using a process server.</param>
        /// <param name="ProcessId">Specifies the process ID of the target process the debugger will attach to.</param>
        /// <param name="AttachFlags">Specifies the flags that control how the debugger attaches to the target process.</param>
        void AttachProcess(
            [In] ulong Server,
            [In] uint ProcessId,
            [In] DebugAttach AttachFlags);

        /// <summary>
        /// The CreateProcess method creates a process from the specified command line.
        /// </summary>
        /// <param name="Server">Specifies the process server to use to attach to the process. If Server is zero, the engine will create a local process without using a process server.</param>
        /// <param name="CommandLine">Specifies the command line to execute to create the new process.</param>
        /// <param name="CreateFlags">Specifies the flags to use when creating the process. When creating and attaching to a process through the debugger engine, set one of the Platform SDK's process creation flags: <see cref="DebugCreateProcess.DebugProcess"/> or <see cref="DebugCreateProcess.DebugOnlyThisProcess"/>.</param>
        void CreateProcess(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] DebugCreateProcess CreateFlags);

        /// <summary>
        /// The CreateProcessAndAttach method creates a process from a specified command line, then attach to another user-mode process. The created process is suspended and only allowed to execute when the attach has completed. This allows rough synchronization when debugging both, client and server processes.
        /// </summary>
        /// <param name="Server">Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to the local process without using a process server.</param>
        /// <param name="CommandLine">Specifies the command line to execute to create the new process. If CommandLine is <c>null</c>, then no process is created and these methods attach to an existing process, as <see cref="AttachProcess"/> does.</param>
        /// <param name="CreateFlags">Specifies the flags to use when creating the process. When creating and attaching to a process through the debugger engine, set one of the Platform SDK's process creation flags: <see cref="DebugCreateProcess.DebugProcess"/> or <see cref="DebugCreateProcess.DebugOnlyThisProcess"/>.</param>
        /// <param name="ProcessId">Specifies the process ID of the target process the debugger will attach to. If ProcessId is zero, the debugger will attach to the process it created from CommandLine.</param>
        /// <param name="AttachFlags">Specifies the flags that control how the debugger attaches to the target process.</param>
        void CreateProcessAndAttach(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] DebugCreateProcess CreateFlags,
            [In] uint ProcessId,
            [In] DebugAttach AttachFlags);

        /// <summary>
        /// The GetProcessOptions method retrieves the process options affecting the current process.
        /// </summary>
        /// <returns>Receives a set of flags representing the process options for the current process.</returns>
        DebugProcess GetProcessOptions();

        /// <summary>
        /// The AddProcessOptions method adds the process options to those options that affect the current process.
        /// </summary>
        /// <param name="Options">Specifies the process options to add to those affecting the current process.</param>
        void AddProcessOptions(
            [In] DebugProcess Options);

        /// <summary>
        /// The RemoveProcessOptions method removes process options from those options that affect the current process.
        /// </summary>
        /// <param name="Options">Specifies the process options to remove from those affecting the current process.</param>
        void RemoveProcessOptions(
            [In] DebugProcess Options);

        /// <summary>
        /// The SetProcessOptions method sets the process options affecting the current process.
        /// </summary>
        /// <param name="Options">Specifies a set of flags that will become the new process options for the current process.</param>
        void SetProcessOptions(
            [In] DebugProcess Options);

        /// <summary>
        /// The OpenDumpFile method opens a dump file as a debugger target.
        /// <note> The engine doesn't completely attach to the dump file until the <see cref="IDebugControl.WaitForEvent"/> method has been called. When a dump file is created from a process or kernel, information about the last event is stored in the dump file. After the dump file is opened, the next time execution is attempted, the engine will generate this event for the event callbacks. Only then does the dump file become available in the debugging session.</note>
        /// </summary>
        /// <param name="DumpFile">Specifies the name of the dump file to open. DumpFile must include the file name extension. DumpFile can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started. DumpFile can have the form of a file URL, starting with "file://". If DumpFile specifies a cabinet (.cab) file, the cabinet file is searched for the first file with extension .kdmp, then .hdmp, then .mdmp, and finally .dmp.</param>
        void OpenDumpFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile);

        /// <summary>
        /// The WriteDumpFile method creates a user-mode or kernel-modecrash dump file.
        /// </summary>
        /// <param name="DumpFile">Specifies the name of the dump file to create. DumpFile must include the file name extension. DumpFile can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.</param>
        /// <param name="Qualifier">Specifies the type of dump file to create.</param>
        void WriteDumpFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile,
            [In] DebugDump Qualifier);

        /// <summary>
        /// The ConnectSession method joins the client to an existing debugger session.
        /// </summary>
        /// <param name="Flags">Specifies a bit-set of option flags for connecting to the session.</param>
        /// <param name="HistoryLimit">Specifies the maximum number of characters from the session's history to send to this client's output upon connection.</param>
        void ConnectSession(
            [In] DebugConnectSession Flags,
            [In] uint HistoryLimit);

        /// <summary>
        /// The StartServer method starts a debugging server.
        /// </summary>
        /// <param name="Options">Specifies the connections options for this server. These are the same options given to the .server debugger command or the WinDbg and CDB -server command-line option. For details on the syntax of this string, see Activating a Debugging Server.</param>
        /// <remarks>The server that is started will be accessible by other debuggers through the transport specified in the Options parameter.</remarks>
        void StartServer(
            [In, MarshalAs(UnmanagedType.LPStr)] string Options);

        /// <summary>
        /// The OutputServers method lists the servers running on a given computer.
        /// </summary>
        /// <param name="OutputControl">Specifies the output control to use while outputting the servers.</param>
        /// <param name="Machine">Specifies the name of the computer whose servers will be listed. Machine has the following form: \\computername </param>
        /// <param name="Flags">Specifies a bit-set that determines which servers to output.</param>
        void OutputServers(
            [In] DebugOutctl OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Machine,
            [In] DebugServers Flags);

        /// <summary>
        /// Attempts to terminate all processes in all targets.
        /// </summary>
        void TerminateProcesses();

        /// <summary>
        /// Detaches the debugger engine from all processes in all targets, resuming all their threads.
        /// </summary>
        void DetachProcesses();

        /// <summary>
        /// The EndSession method ends the current debugger session.
        /// </summary>
        /// <param name="Flags">Specifies how to end the session.</param>
        void EndSession(
            [In] DebugEnd Flags);

        /// <summary>
        /// The GetExitCode method returns the exit code of the current process if that process has already run through to completion.
        /// </summary>
        /// <returns>Returns the exit code of the process. If the process is still running, Code will be set to STILL_ACTIVE.</returns>
        uint GetExitCode();

        /// <summary>
        /// The DispatchCallbacks method lets the debugger engine use the current thread for callbacks.
        /// </summary>
        /// <param name="Timeout">Specifies how many milliseconds to wait before this method will return. If Timeout is uint.MaxValue, this method will not return until <see cref="IDebugClient.ExitDispatch"/> is called or an error occurs.</param>
        void DispatchCallbacks(
            [In] uint Timeout);

        /// <summary>
        /// The ExitDispatch method causes the <see cref="DispatchCallbacks"/> method to return.
        /// </summary>
        /// <param name="Client">Specifies the client whose <see cref="DispatchCallbacks"/> method should return.</param>
        void ExitDispatch(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugClient Client);

        /// <summary>
        /// The CreateClient method creates a new client object for the current thread.
        /// </summary>
        /// <returns>Returns an interface pointer for the new client.</returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        IDebugClient CreateClient();

        /// <summary>
        /// The GetInputCallbacks method returns the input callbacks object registered with this client.
        /// </summary>
        /// <returns>Returns an interface pointer for the <see cref="IDebugInputCallbacks"/> object registered with the client.</returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        IDebugInputCallbacks GetInputCallbacks();

        /// <summary>
        /// The SetInputCallbacks method registers an input callbacks object with the client.
        /// </summary>
        /// <param name="Callbacks">Specifies the interface pointer to the input callbacks object to register with this client.</param>
        void SetInputCallbacks(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugInputCallbacks Callbacks = null);

        /// <summary>
        /// The GetOutputCallbacks method returns the output callbacks object registered with the client.
        /// </summary>
        /// <returns>Returns an interface pointer to the <see cref="IDebugOutputCallbacks"/> object registered with the client.</returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        IDebugOutputCallbacks GetOutputCallbacks();

        /// <summary>
        /// The SetOutputCallbacks method registers an output callbacks object with this client.
        /// </summary>
        /// <param name="Callbacks">Specifies the interface pointer to the output callbacks object to register with this client.</param>
        void SetOutputCallbacks(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugOutputCallbacks Callbacks = null);

        /// <summary>
        /// The GetOutputMask method returns the output mask currently set for the client.
        /// </summary>
        /// <returns>Returns the output mask for the client.</returns>
        DebugOutput GetOutputMask();

        /// <summary>
        /// The SetOutputMask method sets the output mask for the client.
        /// </summary>
        /// <param name="Mask">Specifies the new output mask for the client.</param>
        void SetOutputMask(
            [In] DebugOutput Mask);

        /// <summary>
        /// The GetOtherOutputMask method returns the output mask for another client.
        /// </summary>
        /// <param name="Client">Specifies the client whose output mask is desired.</param>
        /// <returns>Returns the output mask for the client.</returns>
        DebugOutput GetOtherOutputMask(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugClient Client);

        /// <summary>
        /// The SetOtherOutputMask method sets the output mask for another client.
        /// </summary>
        /// <param name="Client">Specifies the client whose output mask will be set.</param>
        /// <param name="Mask">Specifies the new output mask for the client.</param>
        void SetOtherOutputMask(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugClient Client,
            [In] DebugOutput Mask);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        /// <returns></returns>
        uint GetOutputWidth();

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        /// <param name="Columns"></param>
        void SetOutputWidth(
            [In] uint Columns);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        /// <param name="Buffer"></param>
        /// <param name="BufferSize"></param>
        /// <param name="PrefixSize"></param>
        void GetOutputLinePrefix(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint PrefixSize);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        /// <param name="Prefix"></param>
        void SetOutputLinePrefix(
            [In, MarshalAs(UnmanagedType.LPStr)] string Prefix = null);

        /// <summary>
        /// The GetIdentity method returns a string describing the computer and user this client represents.
        /// </summary>
        /// <param name="Buffer">Specifies the buffer to receive the string. If <paramref name="Buffer"/> is <c>null</c>, this information is not returned.</param>
        /// <param name="BufferSize">Specifies the size of the buffer <paramref name="Buffer"/>.</param>
        /// <param name="IdentitySize">Receives the size of the string.</param>
        void GetIdentity(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint IdentitySize);

        /// <summary>
        /// The OutputIdentity method formats and outputs a string describing the computer and user this client represents.
        /// </summary>
        /// <param name="OutputControl">Specifies where to send the output.</param>
        /// <param name="Flags">Set to zero.</param>
        /// <param name="Format">Specifies a format string similar to the printf format string. However, this format string must only contain one formatting directive, %s, which will be replaced by a description of the computer and user this client represents.</param>
        void OutputIdentity(
            [In] DebugOutctl OutputControl,
            [In] uint Flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);

        /// <summary>
        /// The GetEventCallbacks method returns the event callbacks object registered with this client.
        /// </summary>
        /// <returns>Returns an interface pointer to the event callbacks object registered with this client.</returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        IDebugEventCallbacks GetEventCallbacks();

        /// <summary>
        /// The SetEventCallbacks method registers an event callbacks object with this client.
        /// </summary>
        /// <param name="Callbacks">Specifies the interface pointer to the event callbacks object to register with this client.</param>
        void SetEventCallbacks(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugEventCallbacks Callbacks = null);

        /// <summary>
        /// Forces any remaining buffered output to be delivered to the <see cref="IDebugOutputCallbacks"/> object registered with this client.
        /// </summary>
        void FlushCallbacks();
        #endregion

        #region IDebugClient2
        /// <summary>
        /// The WriteDumpFile2 method creates a user-mode or kernel-modecrash dump file.
        /// </summary>
        /// <param name="DumpFile">Specifies the name of the dump file to create. DumpFile must include the file name extension. DumpFile can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.</param>
        /// <param name="Qualifier">Specifies the type of dump file to create.</param>
        /// <param name="FormatFlags">Specifies flags that determine the format of the dump file and--for user-mode minidumps--what information to include in the file.</param>
        /// <param name="Comment">Specifies a comment string to be included in the crash dump file. This string is displayed in the debugger console when the dump file is loaded. Some dump file formats do not support the storing of comment strings.</param>
        void WriteDumpFile2(
            [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile,
            [In] DebugDump Qualifier,
            [In] DebugFormat FormatFlags,
            [In, MarshalAs(UnmanagedType.LPStr)] string Comment = null);

        /// <summary>
        /// The AddDumpInformationFile method registers additional files containing supporting information that will be used when opening a dump file.
        /// <note>ANSI version.</note>
        /// </summary>
        /// <param name="InfoFile">Specifies the name of the file containing the supporting information.</param>
        /// <param name="Type">Specifies the type of the file InfoFile. Currently, only files containing paging file information are supported, and Type must be set to <see cref="DebugDumpFile.PageFileDump"/>.</param>
        void AddDumpInformationFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string InfoFile,
            [In] DebugDumpFile Type);

        /// <summary>
        /// The EndProcessServer method requests that a process server be shut down.
        /// </summary>
        /// <param name="Server">Specifies the process server to shut down. This handle must have been previously returned by <see cref="IDebugClient.ConnectProcessServer"/>.</param>
        void EndProcessServer(
            [In] ulong Server);

        /// <summary>
        /// The WaitForProcessServerEnd method waits for a local process server to exit.
        /// </summary>
        /// <param name="Timeout">Specifies how long in milliseconds to wait for a process server to exit. If Timeout is uint.MaxValue, this method will not return until a process server has ended.</param>
        void WaitForProcessServerEnd(
            [In] uint Timeout);

        /// <summary>
        /// The IsKernelDebuggerEnabled method checks whether kernel debugging is enabled for the local kernel.
        /// </summary>
        /// <returns>S_OK if kernel debugging is enabled for the local kernel; S_FALSE otherwise.</returns>
        [PreserveSig]
        int IsKernelDebuggerEnabled();

        /// <summary>
        /// The TerminateCurrentProcess method attempts to terminate the current process.
        /// </summary>
        void TerminateCurrentProcess();

        /// <summary>
        /// The DetachCurrentProcess method detaches the debugger engine from the current process, resuming all its threads.
        /// </summary>
        void DetachCurrentProcess();

        /// <summary>
        /// The AbandonCurrentProcess method removes the current process from the debugger engine's process list without detaching or terminating the process.
        /// </summary>
        void AbandonCurrentProcess();
        #endregion

        #region IDebugClient3
        /// <summary>
        /// The GetRunningProcessSystemIdByExecutableNameWide method searches for a process with a given executable file name and return its process ID.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="Server">Specifies the process server to search for the executable name. If Server is zero, the engine will search for the executable name among the processes running on the local computer.</param>
        /// <param name="ExeName">Specifies the executable file name for which to search.</param>
        /// <param name="Flags">Specifies a bit-set that controls how the executable name is matched.</param>
        /// <returns>Returns the process ID of the first process to match <paramref name="ExeName"/>.</returns>
        uint GetRunningProcessSystemIdByExecutableNameWide(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ExeName,
            [In] DebugGetProc Flags);

        /// <summary>
        /// The GetRunningProcessDescriptionWide method returns a description of the process that includes the executable image name, the service names, the MTS package names, and the command line.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="Server">Specifies the process server to query for the process description. If Server is zero, the engine will query information about the local process directly.</param>
        /// <param name="SystemId">Specifies the process ID of the process whose description is desired.</param>
        /// <param name="Flags">Specifies a bit-set containing options that affect the behavior of this method.</param>
        /// <param name="ExeName">Receives the name of the executable file used to start the process. If ExeName is <c>null</c>, this information is not returned.</param>
        /// <param name="ExeNameSize">Specifies the size in characters of the buffer <paramref name="ExeName"/>.</param>
        /// <param name="ActualExeNameSize">Receives the size in characters of the executable file name.</param>
        /// <param name="Description">Receives extra information about the process, including service names, MTS package names, and the command line. If Description is <c>null</c>, this information is not returned.</param>
        /// <param name="DescriptionSize">Specifies the size in characters of the buffer <paramref name="Description"/>.</param>
        /// <param name="ActualDescriptionSize">Receives the size in characters of the extra information.</param>
        void GetRunningProcessDescriptionWide(
            [In] ulong Server,
            [In] uint SystemId,
            [In] DebugProcDesc Flags,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder ExeName,
            [In] uint ExeNameSize,
            [Out] out uint ActualExeNameSize,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Description,
            [In] uint DescriptionSize,
            [Out] out uint ActualDescriptionSize);

        /// <summary>
        /// The CreateProcessWide method creates a process from the specified command line.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="Server">Specifies the process server to use when attaching to the process. If Server is zero, the engine will create a local process without using a process server.</param>
        /// <param name="CommandLine">Specifies the command line to execute to create the new process. The CreateProcessWide method might modify the contents of the string that you supply in this parameter. Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string). Passing a constant string in this parameter can lead to an access violation.</param>
        /// <param name="CreateFlags">Specifies the flags to use when creating the process.</param>
        void CreateProcessWide(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] DebugCreateProcess CreateFlags);

        /// <summary>
        /// The CreateProcessAndAttachWide method creates a process from a specified command line, then attach to another user-mode process. The created process is suspended and only allowed to execute when the attach has completed. This allows rough synchronization when debugging both, client and server processes.
        /// </summary>
        /// <param name="Server">Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to the local process without using a process server.</param>
        /// <param name="CommandLine">Specifies the command line to execute to create the new process. If <paramref name="CommandLine"/> is <c>null</c>, then no process is created and these methods attach to an existing process, as <see cref="IDebugClient.AttachProcess"/> does.</param>
        /// <param name="CreateFlags">Specifies the flags to use when creating the process.</param>
        /// <param name="ProcessId">Specifies the process ID of the target process the debugger will attach to. If <paramref name="ProcessId"/> is zero, the debugger will attach to the process it created from <paramref name="CommandLine"/>.</param>
        /// <param name="AttachFlags">Specifies the flags that control how the debugger attaches to the target process.</param>
        void CreateProcessAndAttachWide(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] DebugCreateProcess CreateFlags,
            [In] uint ProcessId,
            [In] DebugAttach AttachFlags);
        #endregion

        #region IDebugClient4
        /// <summary>
        /// The OpenDumpFileWide method opens a dump file as a debugger target.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="FileName">Specifies the name of the dump file to open -- unless <paramref name="FileHandle"/> is not zero, in which case <paramref name="FileName"/> is used only when the engine is queried for the name of the dump file. <paramref name="FileName"/> must include the file name extension. <paramref name="FileName"/> can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started. <paramref name="FileName"/> can also be in the form of a file URL, starting with "file://". If <paramref name="FileName"/> specifies a cabinet (.cab) file, the cabinet file is searched for the first file with extension .kdmp, then .hdmp, then .mdmp, and finally .dmp.</param>
        /// <param name="FileHandle">Specifies the file handle of the dump file to open. If <paramref name="FileHandle"/> is zero, <paramref name="FileName"/> is used to open the dump file. Otherwise, if <paramref name="FileName"/> is not <c>null</c>, the engine returns it when queried for the name of the dump file. If <paramref name="FileHandle"/> is not zero and <paramref name="FileName"/> is <c>null</c>, the engine will return &lt;HandleOnly&gt; for the file name.</param>
        void OpenDumpFileWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string FileName = null,
            [In] ulong FileHandle = default(ulong));

        /// <summary>
        /// The WriteDumpFileWide method creates a user-mode or kernel-modecrash dump file.
        /// <note>Unicode version.</note>
        /// </summary>
        /// <param name="FileName">Specifies the name of the dump file to create. <paramref name="FileName"/> must include the file name extension. <paramref name="FileName"/> can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started. If <paramref name="FileHandle"/> is not 0, <paramref name="FileName"/> is ignored (except when writing status messages to the debugger console).</param>
        /// <param name="FileHandle">Specifies the file handle of the file to write the crash dump to. If <paramref name="FileHandle"/> is 0, the file specified in <paramref name="FileName"/> is used instead.</param>
        /// <param name="Qualifier">Specifies the type of dump to create.</param>
        /// <param name="FormatFlags">Specifies flags that determine the format of the dump file and--for user-mode minidumps--what information to include in the file.</param>
        /// <param name="Comment">Specifies a comment string to be included in the crash dump file. This string is displayed in the debugger console when the dump file is loaded.</param>
        void WriteDumpFileWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string FileName,
            [In] ulong FileHandle = default(ulong),
            [In] DebugDump Qualifier = DebugDump.Default,
            [In] DebugFormat FormatFlags = DebugFormat.Default,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Comment = null);

        /// <summary>
        /// The AddDumpInformationFileWide method registers additional files containing supporting information that will be used when opening a dump file. The ASCII version of this method is <see cref="IDebugClient2.AddDumpInformationFile"/>.
        /// </summary>
        /// <param name="FileName">Specifies the name of the file containing the supporting information. If <paramref name="FileHandle"/> is not zero, <paramref name="FileName"/> is used only for informational purposes.</param>
        /// <param name="FileHandle">Specifies the handle of the file containing the supporting information. If <paramref name="FileHandle"/> is zero, the file named in <paramref name="FileName"/> is used.</param>
        /// <param name="Type">Specifies the type of the file in <paramref name="FileName"/> or <paramref name="FileHandle"/>. Currently, only files containing paging file information are supported, and Type must be set to <see cref="DebugDumpFile.PageFileDump"/>.</param>
        void AddDumpInformationFileWide(
            [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string FileName,
            [In] ulong FileHandle = default(ulong),
            [In] DebugDumpFile Type = DebugDumpFile.PageFileDump);

        /// <summary>
        /// The GetNumberDumpFiles method returns the number of files containing supporting information that were used when opening the current dump target.
        /// </summary>
        /// <returns>Returns the number of files.</returns>
        uint GetNumberDumpFiles();

        /// <summary>
        /// The GetDumpFileWide method describes the files containing supporting information that were used when opening the current dump target.
        /// <note type="note">ANSI version</note>
        /// </summary>
        /// <param name="Index">Specifies which file to describe. Index can take values between zero and the number of files minus one; the number of files can be found by using <see cref="IDebugClient4.GetNumberDumpFiles"/>.</param>
        /// <param name="Buffer">Receives the file name. If <paramref name="Buffer"/> is <c>null</c>, this information is not returned.</param>
        /// <param name="BufferSize">Specifies the size in characters of the buffer <paramref name="Buffer"/>.</param>
        /// <param name="NameSize">Receives the size of the file name.</param>
        /// <param name="Handle">Receives the file handle of the file.</param>
        /// <param name="Type">Receives the type of the file.</param>
        void GetDumpFile(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Handle,
            [Out] out DebugDumpFile Type);

        /// <summary>
        /// The GetDumpFileWide method describes the files containing supporting information that were used when opening the current dump target.
        /// <note type="note">Unicode version</note>
        /// </summary>
        /// <param name="Index">Specifies which file to describe. Index can take values between zero and the number of files minus one; the number of files can be found by using <see cref="IDebugClient4.GetNumberDumpFiles"/>.</param>
        /// <param name="Buffer">Receives the file name. If <paramref name="Buffer"/> is <c>null</c>, this information is not returned.</param>
        /// <param name="BufferSize">Specifies the size in characters of the buffer <paramref name="Buffer"/>.</param>
        /// <param name="NameSize">Receives the size of the file name.</param>
        /// <param name="Handle">Receives the file handle of the file.</param>
        /// <param name="Type">Receives the type of the file.</param>
        void GetDumpFileWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Handle,
            [Out] out DebugDumpFile Type);
        #endregion

        #region IDebugClient5
        /// <summary>
        /// The AttachKernelWide methods connect the debugger engine to a kernel target.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="Flags">Specifies the flags that control how the debugger attaches to the kernel target.</param>
        /// <param name="ConnectOptions">Specifies the connection settings for communicating with the computer running the kernel target.</param>
        void AttachKernelWide(
            [In] DebugAttachKernel Flags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ConnectOptions = null);

        /// <summary>
        /// The GetKernelConnectionOptionsWide method returns the connection options for the current kernel target.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="Buffer">Specifies the buffer to receive the connection options.</param>
        /// <param name="BufferSize">Specifies the size in characters of the buffer Buffer.</param>
        /// <param name="OptionsSize">Receives the size in characters of the connection options.</param>
        void GetKernelConnectionOptionsWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint OptionsSize);

        /// <summary>
        /// The SetKernelConnectionOptionsWide method updates some of the connection options for a live kernel target.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="Options">
        /// Specifies the connection options to update. The possible values are:
        /// <para><c>"resync"</c> Re-synchronize the connection between the debugger engine and the kernel.For more information, see Synchronizing with the Target Computer.</para>
        /// <para><c>"cycle_speed"</c> For kernel connections through a COM port, cycle through the supported baud rates; for other connections, do nothing.</para>
        /// </param>
        void SetKernelConnectionOptionsWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Options);

        /// <summary>
        /// The StartProcessServerWide method starts a process server.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="Flags">Specifies the class of the targets that will be available through the process server. This must be set to <see cref="DebugClass.UserWindows"/>.</param>
        /// <param name="Options">Specifies the connections options for this process server. These are the same options given to the -t option of the DbgSrv command line.</param>
        /// <param name="Reserved">Set to <see cref="IntPtr.Zero"/>.</param>
        void StartProcessServerWide(
            [In] DebugClass Flags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Options,
            [In] IntPtr Reserved = default(IntPtr));

        /// <summary>
        /// The ConnectProcessServerWide methods connect to a process server.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="RemoteOptions">Specifies how the debugger engine will connect with the process server. These are the same options passed to the -premote option on the WinDbg and CDB command lines.</param>
        /// <returns>Returns a handle for the process server. This handle is used when creating or attaching to processes by using the process server.</returns>
        ulong ConnectProcessServerWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string RemoteOptions);

        /// <summary>
        /// The StartServerWide method starts a debugging server.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="Options">Specifies the connections options for this server. These are the same options given to the .server debugger command or the WinDbg and CDB -server command-line option. For details on the syntax of this string, see Activating a Debugging Server.</param>
        /// <remarks>The server that is started will be accessible by other debuggers through the transport specified in the Options parameter.</remarks>
        void StartServerWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Options);

        /// <summary>
        /// The OutputServersWide method lists the servers running on a given computer.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="OutputControl">Specifies the output control to use while outputting the servers.</param>
        /// <param name="Machine">Specifies the name of the computer whose servers will be listed. Machine has the following form: \\computername </param>
        /// <param name="Flags">Specifies a bit-set that determines which servers to output.</param>
        void OutputServersWide(
            [In] DebugOutctl OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Machine,
            [In] DebugServers Flags);

        /// <summary>
        /// The GetOutputCallbacksWide method returns the output callbacks object registered with the client.
        /// </summary>
        /// <returns>Returns an interface pointer to the <see cref="IDebugOutputCallbacksWide"/> object registered with the client.</returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        IDebugOutputCallbacksWide GetOutputCallbacksWide();

        /// <summary>
        /// The SetOutputCallbacksWide method registers an output callbacks object with this client.
        /// </summary>
        /// <param name="Callbacks">Specifies the interface pointer to the output callbacks object to register with this client.</param>
        void SetOutputCallbacksWide(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugOutputCallbacksWide Callbacks = null);

        /// <summary>
        /// Undocumented on MSDN.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="Buffer"></param>
        /// <param name="BufferSize"></param>
        /// <param name="PrefixSize"></param>
        void GetOutputLinePrefixWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint PrefixSize);

        /// <summary>
        /// Undocumented on MSDN.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="Prefix"></param>
        void SetOutputLinePrefixWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Prefix);

        /// <summary>
        /// The GetIdentityWide method returns a string describing the computer and user this client represents.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="Buffer">Specifies the buffer to receive the string. If <paramref name="Buffer"/> is <c>null</c>, this information is not returned.</param>
        /// <param name="BufferSize">Specifies the size of the buffer <paramref name="Buffer"/>.</param>
        /// <param name="IdentitySize">Receives the size of the string.</param>
        void GetIdentityWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint IdentitySize);

        /// <summary>
        /// The OutputIdentityWide method formats and outputs a string describing the computer and user this client represents.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="OutputControl">Specifies where to send the output.</param>
        /// <param name="Flags">Set to zero.</param>
        /// <param name="Format">Specifies a format string similar to the printf format string. However, this format string must only contain one formatting directive, %s, which will be replaced by a description of the computer and user this client represents.</param>
        void OutputIdentityWide(
            [In] DebugOutctl OutputControl,
            [In] uint Flags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Format);

        /// <summary>
        /// The GetEventCallbacksWide method returns the event callbacks object registered with this client.
        /// </summary>
        /// <returns>Returns an interface pointer to the event callbacks object registered with this client.</returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        IDebugEventCallbacksWide GetEventCallbacksWide();

        /// <summary>
        /// The SetEventCallbacksWide method registers an event callbacks object with this client.
        /// </summary>
        /// <param name="Callbacks">Specifies the interface pointer to the event callbacks object to register with this client.</param>
        void SetEventCallbacksWide(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugEventCallbacksWide Callbacks);

        /// <summary>
        /// The CreateProcess2 method executes the given command to create a new process.
        /// <note>ANSI version</note>
        /// </summary>
        /// <param name="Server">Specifies the process server that will be attached to the process. If Server is zero, the engine will create the local process without using a process server.</param>
        /// <param name="CommandLine">Specifies the command line to execute to create the new process.</param>
        /// <param name="OptionsBuffer">Specifies the process creation options.</param>
        /// <param name="OptionsBufferSize">Specifies the size of the buffer <paramref name="OptionsBuffer"/>. This should be set to <c>Marshal.SizeOf(typeof(<see cref="DEBUG_CREATE_PROCESS_OPTIONS"/>))</c>.</param>
        /// <param name="InitialDirectory">Specifies the starting directory for the process. If InitialDirectory is <c>null</c>, the current directory for the process server is used.</param>
        /// <param name="Environment">
        /// Specifies an environment block for the new process. An environment block consists of a null-terminated block of null-terminated strings. Each string is of the form: name=value.
        /// Note that the last two characters of the environment block are both 0: one to terminate the string and one to terminate the block.
        /// If <paramref name="Environment"/> is set to <c>null</c>, the new process inherits the environment block of the process server. If the <see cref="DebugCreateProcess.ThroughRtl"/> flag is set in <paramref name="OptionsBuffer"/>, then <paramref name="Environment"/> must be <c>null</c>.
        /// </param>
        void CreateProcess2(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] uint OptionsBufferSize,
            [In, MarshalAs(UnmanagedType.LPStr)] string InitialDirectory = null,
            [In, MarshalAs(UnmanagedType.LPStr)] string Environment = null);

        /// <summary>
        /// The CreateProcess2Wide method executes the given command to create a new process.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="Server">Specifies the process server that will be attached to the process. If Server is zero, the engine will create the local process without using a process server.</param>
        /// <param name="CommandLine">Specifies the command line to execute to create the new process.</param>
        /// <param name="OptionsBuffer">Specifies the process creation options.</param>
        /// <param name="OptionsBufferSize">Specifies the size of the buffer <paramref name="OptionsBuffer"/>. This should be set to <c>Marshal.SizeOf(typeof(<see cref="DEBUG_CREATE_PROCESS_OPTIONS"/>))</c>.</param>
        /// <param name="InitialDirectory">Specifies the starting directory for the process. If InitialDirectory is <c>null</c>, the current directory for the process server is used.</param>
        /// <param name="Environment">
        /// Specifies an environment block for the new process. An environment block consists of a null-terminated block of null-terminated strings. Each string is of the form: name=value.
        /// Note that the last two characters of the environment block are both 0: one to terminate the string and one to terminate the block.
        /// If <paramref name="Environment"/> is set to <c>null</c>, the new process inherits the environment block of the process server. If the <see cref="DebugCreateProcess.ThroughRtl"/> flag is set in <paramref name="OptionsBuffer"/>, then <paramref name="Environment"/> must be <c>null</c>.
        /// </param>
        void CreateProcess2Wide(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] uint OptionsBufferSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string InitialDirectory = null,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Environment = null);

        /// <summary>
        /// The CreateProcessAndAttach2 method creates a process from a specified command line, then attaches to that process or another user-mode process.
        /// <note>ANSI version</note>
        /// </summary>
        /// <param name="Server">Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to the local process without using a process server.</param>
        /// <param name="CommandLine">Specifies the command line to execute to create the new process. If <paramref name="CommandLine"/> is <c>null</c>, no process is created and these methods will use <paramref name="ProcessId"/> to attach to an existing process.</param>
        /// <param name="OptionsBuffer">Specifies the process creation options.</param>
        /// <param name="OptionsBufferSize">Specifies the size of the buffer <paramref name="OptionsBuffer"/>. This should be set to <c>Marshal.SizeOf(typeof(<see cref="DEBUG_CREATE_PROCESS_OPTIONS"/>))</c>.</param>
        /// <param name="InitialDirectory">Specifies the starting directory for the process. This parameter is used only if <paramref name="CommandLine"/> is not <c>null</c>. If <paramref name="InitialDirectory"/> is <c>null</c>, the current directory for the process server is used.</param>
        /// <param name="Environment">
        /// Specifies an environment block for the new process. An environment block consists of a null-terminated block of null-terminated strings. Each string is of the form: name=value.
        /// Note that the last two characters of the environment block are both 0: one to terminate the string and one to terminate the block.
        /// If <paramref name="Environment"/> is set to <c>null</c>, the new process inherits the environment block of the process server. If the <see cref="DebugCreateProcess.ThroughRtl"/> flag is set in <paramref name="OptionsBuffer"/>, then <paramref name="Environment"/> must be <c>null</c>.
        /// </param>
        /// <param name="ProcessId">Specifies the process ID of the target process to which the debugger will attach. If <paramref name="ProcessId"/> is zero, the debugger will attach to the process it created from <paramref name="CommandLine"/>.</param>
        /// <param name="AttachFlags">Specifies the flags that control how the debugger attaches to the target process.</param>
        void CreateProcessAndAttach2(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] uint OptionsBufferSize,
            [In, MarshalAs(UnmanagedType.LPStr)] string InitialDirectory,
            [In, MarshalAs(UnmanagedType.LPStr)] string Environment,
            [In] uint ProcessId,
            [In] DebugAttach AttachFlags);

        /// <summary>
        /// The CreateProcessAndAttach2Wide method creates a process from a specified command line, then attaches to that process or another user-mode process.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="Server">Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to the local process without using a process server.</param>
        /// <param name="CommandLine">Specifies the command line to execute to create the new process. If <paramref name="CommandLine"/> is <c>null</c>, no process is created and these methods will use <paramref name="ProcessId"/> to attach to an existing process.</param>
        /// <param name="OptionsBuffer">Specifies the process creation options.</param>
        /// <param name="OptionsBufferSize">Specifies the size of the buffer <paramref name="OptionsBuffer"/>. This should be set to <c>Marshal.SizeOf(typeof(<see cref="DEBUG_CREATE_PROCESS_OPTIONS"/>))</c>.</param>
        /// <param name="InitialDirectory">Specifies the starting directory for the process. This parameter is used only if <paramref name="CommandLine"/> is not <c>null</c>. If <paramref name="InitialDirectory"/> is <c>null</c>, the current directory for the process server is used.</param>
        /// <param name="Environment">
        /// Specifies an environment block for the new process. An environment block consists of a null-terminated block of null-terminated strings. Each string is of the form: name=value.
        /// Note that the last two characters of the environment block are both 0: one to terminate the string and one to terminate the block.
        /// If <paramref name="Environment"/> is set to <c>null</c>, the new process inherits the environment block of the process server. If the <see cref="DebugCreateProcess.ThroughRtl"/> flag is set in <paramref name="OptionsBuffer"/>, then <paramref name="Environment"/> must be <c>null</c>.
        /// </param>
        /// <param name="ProcessId">Specifies the process ID of the target process to which the debugger will attach. If <paramref name="ProcessId"/> is zero, the debugger will attach to the process it created from <paramref name="CommandLine"/>.</param>
        /// <param name="AttachFlags">Specifies the flags that control how the debugger attaches to the target process.</param>
        void CreateProcessAndAttach2Wide(
            [In] ulong Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] uint OptionsBufferSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string InitialDirectory,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Environment,
            [In] uint ProcessId,
            [In] DebugAttach AttachFlags);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        /// <param name="NewPrefix"></param>
        /// <param name="Handle"></param>
        void PushOutputLinePrefix(
            [In, MarshalAs(UnmanagedType.LPStr)] string NewPrefix,
            [Out] out ulong Handle);

        /// <summary>
        /// Undocumented on MSDN.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="NewPrefix"></param>
        /// <param name="Handle"></param>
        void PushOutputLinePrefixWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string NewPrefix,
            [Out] out ulong Handle);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        /// <param name="Handle"></param>
        void PopOutputLinePrefix(
            [In] ulong Handle);

        /// <summary>
        /// The GetNumberInputCallbacks method returns the number of input callbacks registered over all clients.
        /// </summary>
        /// <returns>Returns the number of input callbacks that have been registered.</returns>
        uint GetNumberInputCallbacks();

        /// <summary>
        /// The GetNumberOutputCallbacks method returns the number of output callbacks registered over all clients.
        /// </summary>
        /// <returns>Returns the number of output callbacks that have been registered.</returns>
        uint GetNumberOutputCallbacks();

        /// <summary>
        /// The GetNumberEventCallbacks method returns the number of event callbacks that are interested in the given events.
        /// </summary>
        /// <param name="EventFlags">Specifies a set of events used to filter out some of the event callbacks; only event callbacks that have indicated an interest in one of the events in <paramref name="EventFlags"/> will be counted.</param>
        /// <returns>Returns the number of event callbacks that are interested in at least one of the events in <paramref name="EventFlags"/>.</returns>
        uint GetNumberEventCallbacks(
            [In] DebugEvent EventFlags);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        /// <param name="Buffer"></param>
        /// <param name="BufferSize"></param>
        /// <param name="StringSize"></param>
        void GetQuitLockString(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint StringSize);

        /// <summary>
        /// Undocumented on MSDN.
        /// </summary>
        /// <param name="String"></param>
        void SetQuitLockString(
            [In, MarshalAs(UnmanagedType.LPStr)] string String);

        /// <summary>
        /// Undocumented on MSDN.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="Buffer"></param>
        /// <param name="BufferSize"></param>
        /// <param name="StringSize"></param>
        void GetQuitLockStringWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint StringSize);

        /// <summary>
        /// Undocumented on MSDN.
        /// <note>Unicode version</note>
        /// </summary>
        /// <param name="String"></param>
        void SetQuitLockStringWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string String);
        #endregion

        #region IDebugClient6
        /// <summary>
        /// Registers an event callbacks object with this client.
        /// </summary>
        /// <param name="Callbacks">The interface pointer to the event callbacks object.</param>
        void SetEventContextCallbacks(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugEventContextCallbacks Callbacks = null);
        #endregion

#pragma warning restore CS0108 // XXX hides inherited member. This is COM default.

        /// <summary>
        /// The SetClientContext method is reserved for internal use.
        /// </summary>
        /// <param name="Context">The SetClientContext method is reserved for internal use.</param>
        /// <param name="ContextSize">The SetClientContext method is reserved for internal use.</param>
        void SetClientContext(
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] Context,
            [In] uint ContextSize);
    }
}
