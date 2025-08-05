<script>
  import { onMount } from 'svelte';
  import TodoItem from '$lib/components/TodoItem.svelte';

  let todos = [];
  let newTask = '';

  async function fetchTodos() {
    try {
      const response = await fetch('http://localhost:5000/api/todo');
      if (response.ok) {
        todos = await response.json();
      } else {
        console.error('Failed to fetch todos');
      }
    } catch (error) {
      console.error('Error fetching todos:', error);
    }
  }

  async function addTodo() {
    if (!newTask.trim()) return;
    
    try {
      const response = await fetch('http://localhost:5000/api/todo', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          task: newTask,
          isDone: false
        })
      });
      
      if (response.ok) {
        newTask = '';
        await fetchTodos();
      }
    } catch (error) {
      console.error('Error adding todo:', error);
    }
  }

  onMount(() => {
    fetchTodos();
  });
</script>

<main>
  <h1>Todo List</h1>
  
  <div class="add-todo">
    <input bind:value={newTask} placeholder="Add a new task..." />
    <button on:click={addTodo}>Add</button>
  </div>

  <ul>
    {#each todos as todo}
      <li>
        <TodoItem {todo} />
      </li>
    {/each}
  </ul>
</main>

<style>
  main {
    padding: 1rem;
    max-width: 600px;
    margin: auto;
  }

  h1 {
    text-align: center;
  }

  .add-todo {
    display: flex;
    gap: 0.5rem;
    margin-bottom: 1rem;
  }

  .add-todo input {
    flex: 1;
    padding: 0.5rem;
    border: 1px solid #ddd;
    border-radius: 4px;
  }

  .add-todo button {
    padding: 0.5rem 1rem;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
  }

  ul {
    list-style-type: none;
    padding: 0;
  }

  li {
    margin: 0.5rem 0;
  }
</style>