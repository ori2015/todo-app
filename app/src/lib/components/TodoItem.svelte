<script>
  export let todo;
</script>

<div class="todo-item">
  <span class="task" class:completed={todo.isDone}>
    {todo.task}
  </span>
  <span class="status">
    {todo.isDone ? '✅' : '⏳'}
  </span>
</div>

<style>
  .todo-item {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 0.5rem;
    border: 1px solid #ddd;
    border-radius: 4px;
    background-color: #f9f9f9;
  }

  .task.completed {
    text-decoration: line-through;
    color: #888;
  }

  .status {
    font-size: 1.2rem;
  }
</style>
